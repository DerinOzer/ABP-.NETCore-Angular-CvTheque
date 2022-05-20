using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Simphonis.CvTheque.Candidates
{
    public class CandidateManager: DomainService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IRepository<Skill, Guid> _skillRepository;

        public CandidateManager(ICandidateRepository candidateRepository, IRepository<Skill,Guid> skillRepository)
        {
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
        }

        private async Task SetSkillsAsync(Candidate candidate, string[] skills, int[] notes)
        {
            if (skills == null || !skills.Any())
            {
                candidate.RemoveAllSkills();
                return;
            }

            var query = (await _skillRepository.GetQueryableAsync()).Where(x => skills.Contains(x.SkillName)).Select(x => x.Id).Distinct();
            var skillIds = await AsyncExecuter.ToListAsync(query);
            if (!skillIds.Any())
            {
                return;
            }

            candidate.RemoveAllSkillsExcept(skillIds);
            foreach(var skillId in skillIds)
            {
                for(int i = 0; i < skills.Length; i++)
                {
                    Skill skill = await _skillRepository.GetAsync(skillId);
                    if (skill.SkillName == skills[i]){
                        candidate.AddSkill(skillId, notes[i]);
                    }
                }
                
            }
        }

        public async Task<Candidate> CreateCandidateAsync(string name, string lastName, string email, DateTime? availability, int? noticeDuration, DateTime? lastContact, int? currentSalary, int? requestedSalary, string[]? skills, int[]? notes)
        {
            var candidate = new Candidate();
            candidate.Name = name;
            candidate.LastName = lastName;
            candidate.Email = email;
            candidate.Availability = availability;
            candidate.NoticeDuration = noticeDuration;
            candidate.LastContact = lastContact;
            candidate.CurrentSalary = currentSalary;
            candidate.RequestedSalary = requestedSalary;
            await SetSkillsAsync(candidate, skills, notes);
            //await _candidateRepository.InsertAsync(candidate);
            return candidate;
        }

        public async Task UpdateCandidateAsync(Candidate candidate, string name, string lastName, string email, DateTime? availability, int? noticeDuration, DateTime? lastContact, int? currentSalary, int? requestedSalary, /*DateTime? dateCvUpload,*/ string[]? skills, int[]? notes)
        {
            candidate.Name = name;
            candidate.LastName = lastName;
            candidate.Email = email;
            candidate.Availability = availability;
            candidate.NoticeDuration = noticeDuration;
            candidate.LastContact = lastContact;
            candidate.CurrentSalary = currentSalary;
            candidate.RequestedSalary = requestedSalary;
            /*candidate.DateCvUpload = dateCvUpload;*/
            await SetSkillsAsync(candidate, skills, notes);
            await _candidateRepository.UpdateAsync(candidate);
        }

        
    }
}

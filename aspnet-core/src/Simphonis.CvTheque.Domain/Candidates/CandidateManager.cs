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

        private async Task SetSkillsAsync(Candidate candidate, string[] skills)
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
                candidate.AddSkill(skillId);
            }
        }

        public async Task CreateCandidateAsync(string name, string lastName, string email, DateTime? availability, int? noticeDuration, DateTime? lastContact, int? currentSalary, int? requestedSalary, DateTime? dateCvUpload, string[]? skills)
        {
            var candidate = new Candidate(GuidGenerator.Create(), name, lastName, email, availability, noticeDuration, lastContact, currentSalary, requestedSalary, dateCvUpload);
            await SetSkillsAsync(candidate, skills);
            await _candidateRepository.InsertAsync(candidate);
        }

        public async Task UpdateCandidateAsync(Candidate candidate, string name, string lastName, string email, DateTime? availability, int? noticeDuration, DateTime? lastContact, int? currentSalary, int? requestedSalary, DateTime? dateCvUpload, string[]? skills)
        {
            candidate.Name = name;
            candidate.LastName = lastName;
            candidate.Email = email;
            candidate.Availability = availability;
            candidate.NoticeDuration = noticeDuration;
            candidate.LastContact = lastContact;
            candidate.CurrentSalary = currentSalary;
            candidate.RequestedSalary = requestedSalary;
            candidate.DateCvUpload = dateCvUpload;
            await SetSkillsAsync(candidate, skills);
            await _candidateRepository.UpdateAsync(candidate);
        }

        
    }
}

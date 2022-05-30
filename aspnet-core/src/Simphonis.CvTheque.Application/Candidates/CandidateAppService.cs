using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Simphonis.CvTheque.Candidates
{
    public class CandidateAppService : ApplicationService, ICandidateAppService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IRepository<Skill, Guid> _skillRepository;

        public CandidateAppService(ICandidateRepository candidateRepository, IRepository<Skill, Guid> skillRepository)
        {
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
        }

        public async Task CreateCandidateSkillAsync(Guid idCandidate, CreateUpdateCandidateSkillDto input)
        {
            Candidate candidate = await _candidateRepository.GetAsync(idCandidate);
            candidate.AddSkill(input.Id.GetValueOrDefault(), input.Note.GetValueOrDefault());
        }

        public async Task<Guid> GetIdBySkillNameAsync(string name)
        {
            var skills = await _skillRepository.GetListAsync();
            foreach (Skill skill in skills)
            {
                if (skill.SkillName == name)
                {
                    return skill.Id;
                }

            }
            return Guid.Empty;
        }

        public async Task<List<SkillDto>> GetListSkillAsync()
        {
            List<Skill> listSkills = new List<Skill>();
            var skills = await _skillRepository.GetListAsync();
            foreach (Skill skill in skills)
            {
                listSkills.Add(skill);
            }
            return ObjectMapper.Map<List<Skill>,List<SkillDto>>(listSkills);
        }


        public async Task<CandidateDto> CreateAsync(CreateCandidateDto input)
        {
            var Id = Guid.NewGuid();
            Candidate candidate = new Candidate(
                Id,
                input.Name,
                input.LastName,
                input.Email,
                input.Availability,
                input.NoticeDuration,
                input.LastContact,
                input.CurrentSalary,
                input.RequestedSalary);

            if (input.Skills.Any())
            {
                foreach (CreateUpdateCandidateSkillDto Skill in input.Skills)
                {
                    candidate.AddSkill(Skill.Id.GetValueOrDefault(), Skill.Note.GetValueOrDefault());
                }
            }
            await _candidateRepository.InsertAsync(candidate);
            return ObjectMapper.Map<Candidate, CandidateDto>(candidate);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _candidateRepository.DeleteAsync(id);
        }

        public async Task<CandidateDto> GetAsync(Guid id)
        {
            var candidate = await _candidateRepository.GetAsync(id);
            CandidateDto candidateDto = new CandidateDto();
            candidateDto.Id = id;
            candidateDto.Name = candidate.Name;
            candidateDto.LastName = candidate.LastName;
            candidateDto.Email = candidate.Email;
            candidateDto.Availability = candidate.Availability;
            candidateDto.NoticeDuration = candidate.NoticeDuration;
            candidateDto.LastContact = candidate.LastContact;
            candidateDto.CurrentSalary = candidate.CurrentSalary;
            candidateDto.RequestedSalary = candidate.RequestedSalary;
            candidateDto.DateCvUpload = candidate.DateCvUpload;
            foreach(var candidateSkill in candidate.CandidateSkills)
            {
                CreateUpdateCandidateSkillDto temp = new CreateUpdateCandidateSkillDto(candidateSkill.SkillId, candidateSkill.Note);
                candidateDto.Skills.Add(temp);

            }
            return candidateDto;
        }

        public async Task<PagedResultDto<CandidateDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var candidates = await _candidateRepository.GetListAsync();
            var totalCount = await _candidateRepository.CountAsync();
            return new PagedResultDto<CandidateDto>(totalCount, ObjectMapper.Map<List<Candidate>, List<CandidateDto>>(candidates));
        }

        public async Task UpdateAsync(Guid id, UpdateCandidateDto input)
        {
            var candidate = await _candidateRepository.GetAsync(id, includeDetails: true);
            candidate.Name = input.Name;
            candidate.LastName = input.LastName;
            candidate.Email = input.Email;
            candidate.Availability  = input.Availability;
            candidate.NoticeDuration =  input.NoticeDuration;
            candidate.LastContact = input.LastContact;
            candidate.CurrentSalary = input.CurrentSalary;
            candidate.RequestedSalary = input.RequestedSalary;

            if (input.Skills.Any())
            {
                candidate.RemoveAllSkills();
                await _candidateRepository.UpdateAsync(candidate,true);
                foreach (CreateUpdateCandidateSkillDto Skill in input.Skills)
                {
                    candidate.AddSkill(Skill.Id.GetValueOrDefault(), Skill.Note.GetValueOrDefault());
                }
            }
            await _candidateRepository.UpdateAsync(candidate);
        }
    }

}
            

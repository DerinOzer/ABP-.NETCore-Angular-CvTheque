using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Simphonis.CvTheque.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Simphonis.CvTheque.Candidates
{
    [Authorize(CvThequePermissions.Candidates.Default)]
    public class CandidateAppService : ApplicationService, ICandidateAppService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IRepository<Skill, Guid> _skillRepository;

        public CandidateAppService(ICandidateRepository candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }

        public async Task<bool> GetIsUsed(Guid skillId)
        {
            var query = await _candidateRepository.GetQueryableAsync();
            return query.Any(c => c.CandidateSkills.Any(x => x.SkillId == skillId));
        }

        [Authorize(CvThequePermissions.Candidates.Create)]
        public async Task<CandidateDto> CreateAsync(CreateCandidateDto input)
        {
            var id = Guid.NewGuid();
            Candidate candidate = new Candidate(
                id,
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
                    candidate.AddSkill(Skill.SkillId, Skill.Note);
                }
            }
            await _candidateRepository.InsertAsync(candidate);
            return ObjectMapper.Map<Candidate, CandidateDto>(candidate);
        }

        [Authorize(CvThequePermissions.Candidates.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _candidateRepository.DeleteAsync(id);
        }

        public async Task<CandidateDto> GetAsync(Guid id)
        {
            var candidate = await _candidateRepository.GetAsync(id);
            CandidateDto candidateDto = new CandidateDto(
                id,
                candidate.Name,
                candidate.LastName,
                candidate.Email,
                candidate.Availability,
                candidate.NoticeDuration,
                candidate.LastContact,
                candidate.CurrentSalary,
                candidate.RequestedSalary,
                candidate.DateCvUpload);
            
            foreach(var candidateSkill in candidate.CandidateSkills)
            {
                CreateUpdateCandidateSkillDto temp = new CreateUpdateCandidateSkillDto(candidateSkill.SkillId, candidateSkill.Note);
                candidateDto.Skills.Add(temp);

            }
            return candidateDto;
        }

        public async Task<PagedResultDto<CandidateDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Candidate.LastName);
            }
            var candidates = await _candidateRepository.GetListAsync(input.SkipCount,input.MaxResultCount,input.Sorting);

            var totalCount = await _candidateRepository.CountAsync();
            return new PagedResultDto<CandidateDto>(totalCount, ObjectMapper.Map<List<Candidate>, List<CandidateDto>>(candidates));
        }

        [Authorize(CvThequePermissions.Candidates.Edit)]
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
                    candidate.AddSkill(Skill.SkillId, Skill.Note);
                }
            }
            await _candidateRepository.UpdateAsync(candidate);
        }
    }
}
            

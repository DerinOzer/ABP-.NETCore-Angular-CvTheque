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
    public class CandidateAppService : CvThequeAppService, ICandidateAppService
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IRepository<Skill, Guid> _skillRepository;
        private readonly CandidateManager _candidateManager;

        public CandidateAppService(ICandidateRepository candidateRepository, IRepository<Skill, Guid> skillRepository, CandidateManager candidateManager)
        {
            _candidateRepository = candidateRepository;
            _skillRepository = skillRepository;
            _candidateManager = candidateManager;
        }

        public async Task<CandidateDto> CreateAsync(CreateCandidateDto input)
        {
            Candidate candidate = await _candidateManager.CreateCandidateAsync(
                input.Name,
                input.LastName,
                input.Email,
                input.Availability,
                input.NoticeDuration,
                input.LastContact,
                input.CurrentSalary,
                input.RequestedSalary,
                input.Skills,
                input.Notes);
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
            return ObjectMapper.Map<Candidate, CandidateDto>(candidate);
        }

        public async Task<PagedResultDto<CandidateDto>> GetListAsync(CandidateGetListInput input)
        {
            var candidates = await _candidateRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount);
            var totalCount = await _candidateRepository.CountAsync();
            return new PagedResultDto<CandidateDto>(totalCount, ObjectMapper.Map<List<Candidate>, List<CandidateDto>>(candidates));
        }
        public async Task<ListResultDto<SkillLookupDto>> GetSkillLookupAsync()
        {
            var skills = await _skillRepository.GetListAsync();
            return new ListResultDto<SkillLookupDto>(ObjectMapper.Map<List<Skill>,List<SkillLookupDto>>(skills));
        }

        public async Task UpdateAsync(Guid id, UpdateCandidateDto input)
        {
            var candidate = await _candidateRepository.GetAsync(id, includeDetails: true);
            await _candidateManager.UpdateCandidateAsync(candidate,
                input.Name,
                input.LastName,
                input.Email,
                input.Availability,
                input.NoticeDuration,
                input.LastContact,
                input.CurrentSalary,
                input.RequestedSalary,
                input.Skills,
                input.Notes);

        }
    }

}
            

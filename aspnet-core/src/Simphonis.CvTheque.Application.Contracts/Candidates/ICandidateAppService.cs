using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simphonis.CvTheque.Candidates
{
    public interface ICandidateAppService : IApplicationService
    {
        Task<PagedResultDto<CandidateDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<CandidateDto> GetAsync(Guid id);
        Task<CandidateDto> CreateAsync(CreateCandidateDto input);
        Task UpdateAsync(Guid id, UpdateCandidateDto input);
        Task DeleteAsync(Guid id);

    }
}

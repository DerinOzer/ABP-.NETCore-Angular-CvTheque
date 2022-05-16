using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simphonis.CvTheque.Candidates
{
    public interface ICandidateAppService : ICrudAppService<CandidateDto,
            Guid, //Primary key of the candiate entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateCandidateDto, UpdateCandidateDto>
    {

    }
}

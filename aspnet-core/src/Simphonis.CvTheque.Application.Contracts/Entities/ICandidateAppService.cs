using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simphonis.CvTheque.Entities
{
    public interface ICandidateAppService : ICrudAppService<CandidateDto, 
            Guid, //Primary key of the candiate entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateCandidateDto, UpdateCandidateDto>
    {

    }
}

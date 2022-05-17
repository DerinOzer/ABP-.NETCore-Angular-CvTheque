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
    public class CandidateAppService : CrudAppService<Candidate, CandidateDto,
            Guid, //Primary key of the candiate entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateCandidateDto, UpdateCandidateDto>,
        ICandidateAppService
    {
        public CandidateAppService(IRepository<Candidate, Guid> repository)
            : base(repository)
        {
        }
    }
            
}
            

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simphonis.CvTheque.Candidates
{
    public interface ICandidateSkillAppService : ICrudAppService<CandidateSkillDto,
            Guid, PagedAndSortedResultRequestDto, CreateUpdateCandidateSkillDto>
    {
    }
}

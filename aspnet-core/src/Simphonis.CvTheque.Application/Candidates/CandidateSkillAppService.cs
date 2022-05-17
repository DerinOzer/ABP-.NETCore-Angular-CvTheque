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
    public class CandidateSkillAppService : CrudAppService<CandidateSkill,CandidateSkillDto,
            Guid, PagedAndSortedResultRequestDto, CreateUpdateCandidateSkillDto>, ICandidateSkillAppService
    {
        public CandidateSkillAppService(IRepository<CandidateSkill, Guid> repository): base(repository)
        {
        }
        
    }
}

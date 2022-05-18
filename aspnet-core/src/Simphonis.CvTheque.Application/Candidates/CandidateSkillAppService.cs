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
    public class CandidateSkillAppService : CrudAppService<Skill,CandidateSkillDto,
            Guid, PagedAndSortedResultRequestDto, CreateUpdateCandidateSkillDto>, ISkillAppService
    {
        public CandidateSkillAppService(IRepository<Skill, Guid> repository): base(repository)
        {
        }
        
    }
}

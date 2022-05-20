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
    public class SkillAppService : CrudAppService<Skill,SkillDto,
            Guid, PagedAndSortedResultRequestDto, CreateUpdateSkillDto>, ISkillAppService
    {
        public SkillAppService(IRepository<Skill, Guid> repository): base(repository)
        {
        }
        
    }
}

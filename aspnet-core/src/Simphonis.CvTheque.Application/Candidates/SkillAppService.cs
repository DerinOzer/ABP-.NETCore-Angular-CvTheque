using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simphonis.CvTheque.Permissions;
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
            GetPolicyName = CvThequePermissions.Skills.Default;
            GetListPolicyName = CvThequePermissions.Skills.Default;
            CreatePolicyName = CvThequePermissions.Skills.Create;
            UpdatePolicyName = CvThequePermissions.Skills.Edit;
            DeletePolicyName = CvThequePermissions.Skills.Delete;
        }
        
    }
}

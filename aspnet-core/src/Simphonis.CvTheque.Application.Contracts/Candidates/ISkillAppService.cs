using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Simphonis.CvTheque.Candidates
{
    public interface ISkillAppService : ICrudAppService<SkillDto,
            Guid, PagedAndSortedResultRequestDto, CreateUpdateSkillDto>
    {
    }
}

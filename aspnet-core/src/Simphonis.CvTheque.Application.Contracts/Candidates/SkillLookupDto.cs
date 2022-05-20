using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Simphonis.CvTheque.Candidates
{
    public class SkillLookupDto : EntityDto<Guid>
    {
        public string SkillName { get; set; }
    }
}

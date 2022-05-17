using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Simphonis.CvTheque.Candidates
{
    public class CandidateSkillDto : AuditedEntityDto<Guid>
    {
        public string SkillName { get; set; }
    }
}

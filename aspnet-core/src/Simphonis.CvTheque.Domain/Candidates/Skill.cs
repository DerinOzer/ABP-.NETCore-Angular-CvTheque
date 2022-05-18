using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simphonis.CvTheque.Candidates
{
    public class Skill: AuditedAggregateRoot<Guid>
    {
        public string SkillName { get; set; }

        private Skill() { }

        public Skill(Guid id, string skillName):base(id)
        {
            SkillName = skillName;
        }
    }
}

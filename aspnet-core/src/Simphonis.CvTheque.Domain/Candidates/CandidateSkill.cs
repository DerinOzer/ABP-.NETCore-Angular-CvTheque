using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simphonis.CvTheque.Candidates
{
    public class CandidateSkill: AuditedAggregateRoot<Guid>
    {
        public string SkillName { get; set; }
        //public ICollection<Candidate> Candidates { get; set; }
        public List<Candidate_CandidateSkill> CandidateCandidateSkills { get; set; }
    }
}

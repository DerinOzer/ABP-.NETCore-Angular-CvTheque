using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Simphonis.CvTheque.Candidates
{
    public class Candidate_CandidateSkill: Entity
    {
        

        public Guid IdCandidate { get; set; }
        public Candidate Candidate { get; set; }

        public Guid IdCandidateSkill { get; set; }
        public CandidateSkill CandidateSkill { get; set; }

        public override object[] GetKeys()
        {
            return new object[] { IdCandidate, IdCandidateSkill };
        }
    }
}

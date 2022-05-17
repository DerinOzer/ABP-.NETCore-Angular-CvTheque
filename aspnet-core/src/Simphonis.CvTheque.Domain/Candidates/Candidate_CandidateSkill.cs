using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simphonis.CvTheque.Candidates
{
    public class Candidate_CandidateSkill
    {
        public Guid Id { get; set; }

        public Guid IdCandidate { get; set; }
        public Candidate Candidate { get; set; }

        public Guid IdCandidateSkill { get; set; }
        public CandidateSkill CandidateSkill { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;


namespace Simphonis.CvTheque.Candidates
{
    public class CandidateSkill : Entity
    {
        public Guid IdCandidate { get; set; }
        public Candidate Candidate { get; set; }

        public Guid IdSkill { get; set; }
        public Skill Skill { get; set; }

        public int Note { get; set; }

        private CandidateSkill() { }

        public CandidateSkill(Guid idCandidate, Guid idSkill, int note)
        {
            IdCandidate = idCandidate;
            IdSkill = idSkill;
            Note = note;
        }

        public override object[] GetKeys()
        {
            return new object[] { IdCandidate, IdSkill};
        }
    }
}

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
        public Guid CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }

        public int Note { get; set; }

        private CandidateSkill() { }

        public CandidateSkill(Guid idCandidate, Guid idSkill, int note)
        {
            CandidateId = idCandidate;
            SkillId = idSkill;
            Note = note;
        }

        public override object[] GetKeys()
        {
            return new object[] { CandidateId, SkillId};
        }
    }
}

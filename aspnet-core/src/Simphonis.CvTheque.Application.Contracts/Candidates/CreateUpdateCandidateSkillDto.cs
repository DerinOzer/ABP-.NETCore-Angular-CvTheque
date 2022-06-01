using System;
using System.Collections.Generic;
using System.Text;

namespace Simphonis.CvTheque.Candidates
{
    public class CreateUpdateCandidateSkillDto
    {
        public Guid SkillId { get; set; }
        public int Note { get; set; }

        public CreateUpdateCandidateSkillDto(Guid skillId, int note)
        {
            SkillId = skillId;
            Note = note;
        }

        public CreateUpdateCandidateSkillDto() { }
    }
}

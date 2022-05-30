using System;
using System.Collections.Generic;
using System.Text;

namespace Simphonis.CvTheque.Candidates
{
    public class CreateUpdateCandidateSkillDto
    {
        public Guid? Id { get; set; }
        public int? Note { get; set; }

        public CreateUpdateCandidateSkillDto(Guid? id, int? note)
        {
            Id = id;
            Note = note;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Simphonis.CvTheque.Candidates
{
    public class CreateUpdateSkillDto
    {
        [Required]
        [StringLength(70)]
        public string SkillName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Simphonis.CvTheque.Entities
{
    public class UpdateCandidateDto
    {
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Availability { get; set; }

        [Display(Name = "Duration of Notice")]
        public int NoticeDuration { get; set; } // Days.

        [Display(Name = "Date of Last Contact")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime LastContact { get; set; } // The date of last contact by the recruiter.

        [Display(Name = "Current Salary")]
        public int CurrentSalary { get; set; }

        [Display(Name = "Requested Salary")]
        public int RequestedSalary { get; set; }
    }
}

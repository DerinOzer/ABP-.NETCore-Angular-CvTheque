using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Simphonis.CvTheque.Candidates
{
    public class CreateCandidateDto
    {
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        public string Email { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime? Availability { get; set; }

        /// <summary>
        /// Days
        /// </summary>
        [Display(Name = "Duration of Notice")]
        public int? NoticeDuration { get; set; }

        /// <summary>
        /// The date of last contact with the recruiter.
        /// </summary>
        [Display(Name = "Date of Last Contact")]
        [DataType(DataType.Date)]
        public DateTime? LastContact { get; set; }

        [Display(Name = "Current Salary")]
        public int? CurrentSalary { get; set; }

        [Display(Name = "Requested Salary")]
        public int? RequestedSalary { get; set; }
        public string[]? Skills { get; set; }
        public int[]? Notes { get; set; }

    }
}

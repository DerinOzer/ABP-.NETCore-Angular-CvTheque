using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Simphonis.CvTheque.Entities
{
    public class CandidateDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Availability { get; set; }
        public int NoticeDuration { get; set; } // Days.
        public DateTime LastContact { get; set; } // The date of last contact by the recruiter.
        public int CurrentSalary { get; set; }
        public int RequestedSalary { get; set; }
    }
}

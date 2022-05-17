using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Simphonis.CvTheque.Candidates
{
    public class Candidate : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Availability { get; set; }
        /// <summary>
        /// Days
        /// </summary>
        public int? NoticeDuration { get; set; }
        /// <summary>
        /// The date of last contact with the recruiter.
        /// </summary>
        public DateTime? LastContact { get; set; }
        public int? CurrentSalary { get; set; }
        public int? RequestedSalary { get; set; }
        /// <summary>
        /// The date the CV was uploaded.
        /// </summary>
        public DateTime? DateCvUpload { get; set; }

        public ICollection<CandidateSkill> CandidateSkills { get; set; }

    }
}

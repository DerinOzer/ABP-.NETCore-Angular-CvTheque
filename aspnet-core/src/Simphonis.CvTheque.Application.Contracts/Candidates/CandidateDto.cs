using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Simphonis.CvTheque.Candidates
{
    public class CandidateDto : AuditedEntityDto<Guid>
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

        public ICollection<CreateUpdateCandidateSkillDto> Skills { get; set; } = new Collection<CreateUpdateCandidateSkillDto>();

        public CandidateDto(Guid id, string name, string lastName, string email, DateTime? availability, int? noticeDuration, DateTime? lastContact, int? currentSalary, int? requestedSalary, DateTime? dateCvUpload)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Email = email;
            Availability = availability;
            NoticeDuration = noticeDuration;
            LastContact = lastContact;
            CurrentSalary = currentSalary;
            RequestedSalary = requestedSalary;
            DateCvUpload = dateCvUpload;
        }

        public CandidateDto() { }
    }
}

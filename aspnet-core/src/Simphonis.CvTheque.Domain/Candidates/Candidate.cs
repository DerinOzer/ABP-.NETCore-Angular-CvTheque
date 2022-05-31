using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
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
    
        public ICollection<CandidateSkill> CandidateSkills { get; set; } = new Collection<CandidateSkill>();

        private Candidate() { }

        public Candidate(Guid id, string name, string lastName, string email, DateTime? availability, int? noticeDuration, DateTime? lastContact, int? currentSalary, int? requestedSalary):base(id)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Availability = availability;
            NoticeDuration = noticeDuration;
            LastContact = lastContact;
            CurrentSalary = currentSalary;
            RequestedSalary = requestedSalary;
        }

        public List<CandidateSkill> GetList()
        {
            return CandidateSkills.ToList();
        }
        public bool IsInSkill(Guid skillId)
        {
            return CandidateSkills.Any(x => x.SkillId == skillId);
        }

        public CandidateSkill Get(Guid skillId)
        {
            return CandidateSkills.FirstOrDefault(x => x.SkillId == skillId);
        }

        public void AddSkill(Guid skillId, int note)
        {
            Check.NotNull(skillId, nameof(skillId));
            if (IsInSkill(skillId))
            {
                return;
            } 
            CandidateSkills.Add(new CandidateSkill(idCandidate: Id, skillId, note));
        }

        public void RemoveSkill(Guid skillId)
        {
            Check.NotNull(skillId, nameof(skillId));
            if (!IsInSkill(skillId))
            {
                return;
            }
        }

        public void RemoveAllSkills()
        {
            CandidateSkills.RemoveAll(x => x.CandidateId == Id);
        }

        public void RemoveAllSkillsExcept(List<Guid> skillIds)
        {
            Check.NotNullOrEmpty(skillIds, nameof(skillIds));
            CandidateSkills.RemoveAll(x => !skillIds.Contains(x.SkillId));
        }
    }
}

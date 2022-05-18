using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Simphonis.CvTheque.Candidates
{
    public interface ICandidateSkillAppService : IApplicationService
    {
        Task<CandidateDto> AddSkillToCandidate(CandidateSkillCandidateDto candidateSkillCandidate);
    }
}

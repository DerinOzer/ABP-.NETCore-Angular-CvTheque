using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Simphonis.CvTheque.Candidates
{
    public interface ICandidateRepository : IRepository<Candidate, Guid>
    {
        Task<List<CandidateDetails>> GetListAsync(string sorting, int skipCount, int maxResultCount, CancellationToken cancellationToken = default);
        Task<CandidateDetails> GetAsync(Guid id, CancellationToken cancellationToken = default);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Simphonis.CvTheque.Candidates
{
    public interface ICandidateRepository:IRepository<Candidate,Guid>
    {
        Task<List<Candidate>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Simphonis.CvTheque.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Simphonis.CvTheque.Candidates
{
    public class EfCoreCandidateRepository : EfCoreRepository<CvThequeDbContext, Candidate, Guid>, ICandidateRepository
    {
        public EfCoreCandidateRepository(IDbContextProvider<CvThequeDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<List<Candidate>> GetListAsync(int skipCount,int maxResultCount,string sorting)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.OrderBy(sorting).Skip(skipCount).Take(maxResultCount).ToListAsync();
        }

        public override async Task<IQueryable<Candidate>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}

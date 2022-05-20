using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simphonis.CvTheque.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading;

namespace Simphonis.CvTheque.Candidates
{
    public class EfCoreCandidateRepository : EfCoreRepository<CvThequeDbContext, Candidate, Guid>, ICandidateRepository
    {
        public EfCoreCandidateRepository(IDbContextProvider<CvThequeDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Candidate> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var query = await ApplyFilterAsync();
            return await query.Where(x => x.Id == id).FirstOrDefaultAsync(GetCancellationToken(cancellationToken));

        }


        public async Task<List<Candidate>> GetListAsync(string sorting, int skipCount, int maxResultCount, CancellationToken cancellationToken = default)
        {
            var query = await ApplyFilterAsync();
            //Can cause problem !!
            return await query.OrderBy(x => string.IsNullOrEmpty(sorting)? sorting : nameof(Candidate.LastName)).PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        private async  Task<IQueryable<Candidate>> ApplyFilterAsync()
        {
            var dbContext = await GetDbContextAsync();
            return (await GetDbSetAsync()).Include(x => x.CandidateSkills).Select(x => new Candidate
            {
                Name = x.Name,
                LastName= x.LastName,
                Email= x.Email,
                Availability= x.Availability,
                NoticeDuration= x.NoticeDuration,
                LastContact = x.LastContact,
                CurrentSalary = x.CurrentSalary,
                RequestedSalary = x.RequestedSalary,
                DateCvUpload = x.DateCvUpload,
                CandidateSkills = x.CandidateSkills
            });
        }

        public override Task<IQueryable<Candidate>> WithDetailsAsync()
        {
            return base.WithDetailsAsync(x => x.CandidateSkills);
        }
    }
}

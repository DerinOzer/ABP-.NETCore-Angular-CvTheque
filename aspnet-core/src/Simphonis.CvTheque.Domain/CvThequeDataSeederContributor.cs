using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Simphonis.CvTheque.Candidates;

namespace Simphonis.CvTheque
{
    internal class CvThequeDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Candidate, Guid> _candidateRepository;

        public CvThequeDataSeederContributor(IRepository<Candidate, Guid> candidateRepository)
        {
            _candidateRepository = candidateRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _candidateRepository.GetCountAsync() <= 0)
            {
                await _candidateRepository.InsertAsync(
                    new Candidate
                    {
                        Name = "Derin",
                        LastName = "Ozer",
                        Email = "derin.ozer@simphonis.com",
                        Availability = new DateTime(2022, 08, 12),
                        NoticeDuration = 45,
                        LastContact = new DateTime(2022, 04, 04),
                        CurrentSalary = 1000,
                        RequestedSalary = 1500
                    },
                    autoSave: true
                );
                

                await _candidateRepository.InsertAsync(
                    new Candidate
                    {
                        Name = "Xavier",
                        LastName = "Roger-Machart",
                        Email = "xavier.roger-machart@orkeis.fr",
                        Availability = new DateTime(2022, 07, 25),
                        NoticeDuration = 60,
                        LastContact = new DateTime(2022, 03, 29),
                        CurrentSalary = 3000,
                        RequestedSalary = 4000
                    },
                    autoSave: true
                );
            }
        }

    }
}

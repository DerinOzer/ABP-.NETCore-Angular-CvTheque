using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Simphonis.CvTheque.Entities;

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
                        Availability = DateTime.Parse("2022-8-12"),
                        NoticeDuration = 45,
                        LastContact = DateTime.Parse("2022-4-4"),
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
                        Availability = DateTime.Parse("2022-7-25"),
                        NoticeDuration = 60,
                        LastContact = DateTime.Parse("2022-3-29"),
                        CurrentSalary = 3000,
                        RequestedSalary = 4000
                    },
                    autoSave: true
                );
            }
        }

    }
}

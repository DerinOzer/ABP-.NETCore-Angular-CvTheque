using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Simphonis.CvTheque.Data;
using Volo.Abp.DependencyInjection;

namespace Simphonis.CvTheque.EntityFrameworkCore;

public class EntityFrameworkCoreCvThequeDbSchemaMigrator
    : ICvThequeDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCvThequeDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the CvThequeDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CvThequeDbContext>()
            .Database
            .MigrateAsync();
    }
}

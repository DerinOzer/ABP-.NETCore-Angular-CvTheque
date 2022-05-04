using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Simphonis.CvTheque.Data;

/* This is used if database provider does't define
 * ICvThequeDbSchemaMigrator implementation.
 */
public class NullCvThequeDbSchemaMigrator : ICvThequeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

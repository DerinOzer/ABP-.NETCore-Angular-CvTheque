using System.Threading.Tasks;

namespace Simphonis.CvTheque.Data;

public interface ICvThequeDbSchemaMigrator
{
    Task MigrateAsync();
}

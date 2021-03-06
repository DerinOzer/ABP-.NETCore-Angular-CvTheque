using Simphonis.CvTheque.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Simphonis.CvTheque.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CvThequeEntityFrameworkCoreModule),
    typeof(CvThequeApplicationContractsModule)
    )]
    public class CvThequeDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}

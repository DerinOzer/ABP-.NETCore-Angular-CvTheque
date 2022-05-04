using Volo.Abp.Modularity;

namespace Simphonis.CvTheque;

[DependsOn(
    typeof(CvThequeApplicationModule),
    typeof(CvThequeDomainTestModule)
    )]
public class CvThequeApplicationTestModule : AbpModule
{

}

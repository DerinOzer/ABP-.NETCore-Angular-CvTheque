using Simphonis.CvTheque.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Simphonis.CvTheque;

[DependsOn(
    typeof(CvThequeEntityFrameworkCoreTestModule)
    )]
public class CvThequeDomainTestModule : AbpModule
{

}

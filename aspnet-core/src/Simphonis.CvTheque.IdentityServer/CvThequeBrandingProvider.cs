using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Simphonis.CvTheque;

[Dependency(ReplaceServices = true)]
public class CvThequeBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "CvTheque";
}

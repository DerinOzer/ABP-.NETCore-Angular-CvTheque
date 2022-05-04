using Simphonis.CvTheque.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Simphonis.CvTheque.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class CvThequeController : AbpControllerBase
{
    protected CvThequeController()
    {
        LocalizationResource = typeof(CvThequeResource);
    }
}

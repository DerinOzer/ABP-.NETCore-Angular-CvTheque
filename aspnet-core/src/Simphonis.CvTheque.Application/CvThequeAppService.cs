using System;
using System.Collections.Generic;
using System.Text;
using Simphonis.CvTheque.Localization;
using Volo.Abp.Application.Services;

namespace Simphonis.CvTheque;

/* Inherit your application services from this class.
 */
public abstract class CvThequeAppService : ApplicationService
{
    protected CvThequeAppService()
    {
        LocalizationResource = typeof(CvThequeResource);
    }
}

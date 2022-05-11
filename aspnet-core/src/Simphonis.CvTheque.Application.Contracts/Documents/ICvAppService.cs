using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Simphonis.CvTheque.Documents
{
    public interface ICvAppService : IApplicationService
    {
        Task SaveCvAsync(SaveCvDto input);
        Task<CvDto> GetCvAsync(GetCvDto input);
    }
}

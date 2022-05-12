using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Simphonis.CvTheque.Documents
{
    public interface ICvAppService : IApplicationService
    {
        void UploadCvAsync(IFormFile file);
        Task<FileResult> DownloadCvAsync(Guid id);
    }
}

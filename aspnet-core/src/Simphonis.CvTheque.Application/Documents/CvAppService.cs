using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;


namespace Simphonis.CvTheque.Documents
{
    public class CvAppService : ApplicationService, ICvAppService
    {
        private readonly IBlobContainer<CvContainer> _cvContainer;

        public CvAppService(IBlobContainer<CvContainer> container)
        {
            _cvContainer = container;
        }

        public virtual async void UploadCvAsync(IFormFile file)
        {
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream).ConfigureAwait(false);
            var id = Guid.NewGuid().ToString("N");
            await _cvContainer.SaveAsync(id + ".pdf", memoryStream.ToArray()).ConfigureAwait(false);
        }

        public async Task<FileResult> DownloadCvAsync(Guid id)
        {
            var cv = await _cvContainer.GetAllBytesOrNullAsync(id.ToString()+".pdf").ConfigureAwait(false);
            return new FileContentResult(cv, "application/pdf");  

        }
    }
}

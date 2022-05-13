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
using Simphonis.CvTheque.Candidates;


namespace Simphonis.CvTheque.Documents
{
    public class CvAppService : ApplicationService, ICvAppService
        //L'injection de constructeur
    {
        private readonly IBlobContainer<CvContainer> _cvContainer;

        public CvAppService(IBlobContainer<CvContainer> container)
        {
            _cvContainer = container;
        }

        public virtual async Task UploadCvAsync(Guid id, IFormFile file)
        {
            //CandidateDto candidate = GetAsync(guid);
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream).ConfigureAwait(false);
            //var id = Guid.NewGuid().ToString("N");
            await _cvContainer.SaveAsync(id.ToString() + ".pdf", memoryStream.ToArray(),true).ConfigureAwait(false);
        }

        public async Task<FileResult> GetCvAsync(Guid id)
        {
            var cv = await _cvContainer.GetAllBytesOrNullAsync(id.ToString()+".pdf").ConfigureAwait(false);
            return new FileContentResult(cv, "application/pdf");  

        }
    }
}

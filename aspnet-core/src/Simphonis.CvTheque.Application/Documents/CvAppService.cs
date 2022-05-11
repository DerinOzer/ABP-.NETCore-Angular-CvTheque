using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simphonis.CvTheque.Candidates;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;

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
            await _cvContainer.SaveAsync(file.Name + ".pdf", memoryStream.ToArray()).ConfigureAwait(false);
        }

        public async Task<FileResult> DownloadCvAsync(string fileName)
        {
            var cv = await _cvContainer.GetAllBytesOrNullAsync(fileName).ConfigureAwait(false);
            return new FileContentResult(cv, "application/pdf");  

        }

        /*public async Task<SaveCvDto> SaveCvAsync([FromForm] IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream).ConfigureAwait(false);
            var newFile = new Cv(file.Length, file.ContentType, file.Name);
            await _cvContainer.SaveAsync("test", memoryStream.ToArray()).ConfigureAwait(false);

            return new SaveCvDto
            {
                Name = newFile.Name,
                FileSize = newFile.FileSize,
                FileType = newFile.FileType,
            };
        }*/
        /*public async Task SaveCvAsync(SaveCvDto input)
        {
            await _cvContainer.SaveAsync(input.Name, input.Content, true);
        }*/

        /*public async Task<CvDto> GetCvAsync(GetCvDto input)
        {
            var cv = await _cvContainer.GetAllBytesAsync(input.Name);

            return new CvDto
            {
                Name = input.Name,
            };
        }*/
    }
}

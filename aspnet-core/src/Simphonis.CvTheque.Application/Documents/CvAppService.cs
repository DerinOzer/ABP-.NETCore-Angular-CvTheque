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
using Volo.Abp.Domain.Repositories;

namespace Simphonis.CvTheque.Documents
{
    public class CvAppService : ApplicationService, ICvAppService
        //L'injection de constructeur
    {
        private readonly IBlobContainer<CvContainer> _cvContainer;
        private readonly IRepository<Candidate, Guid> _repository;

        public CvAppService(IBlobContainer<CvContainer> container, IRepository<Candidate, Guid> repository)
        {
            _cvContainer = container;
            _repository = repository;
        }

        public virtual async Task UploadCvAsync(Guid id, IFormFile file)
        {
            Candidate candidate = await _repository.GetAsync(id);
            DateTime today = DateTime.Now;
            candidate.DateAdded = today;
            await _repository.UpdateAsync(candidate);
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream).ConfigureAwait(false);
            await _cvContainer.SaveAsync(id.ToString() + ".pdf", memoryStream.ToArray(),true).ConfigureAwait(false);
        }

        public async Task<FileResult> GetCvAsync(Guid id)
        {
            var cv = await _cvContainer.GetAllBytesOrNullAsync(id.ToString()+".pdf").ConfigureAwait(false);
            return new FileContentResult(cv, "application/pdf");  

        }
    }
}

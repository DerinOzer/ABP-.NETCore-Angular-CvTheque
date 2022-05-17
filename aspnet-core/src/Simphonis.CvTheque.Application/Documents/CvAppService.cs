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
            candidate.DateCvUpload = DateTime.Now;
            await _repository.UpdateAsync(candidate);
            using (Stream stream = file.OpenReadStream())
            {
                await _cvContainer.SaveAsync(id.ToString() + ".pdf", stream, true);
            }
        }

        public async Task<FileResult> GetCvAsync(Guid id)
        {
            Candidate candidate = await _repository.GetAsync(id); // This method throws an exception if the candidate doesn't exist.
            var cv = await _cvContainer.GetAllBytesOrNullAsync(id.ToString()+".pdf");
            return new FileContentResult(cv, "application/pdf");  

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Simphonis.CvTheque.Entities;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;

namespace Simphonis.CvTheque.Blob
{
    [Authorize]
    public class BlobAppService : ApplicationService
    {
        private readonly IBlobContainer _blobContainer;

        public BlobAppService(IBlobContainerFactory blobContainerFactory)
        {
            _blobContainer = blobContainerFactory.Create("CvTheque-CVs");
        }

        public async Task SaveCvAsync(byte[] bytes, Candidate candidate)
        {
            var blobName = candidate.Name + "-" + candidate.LastName + "-CV";
            await _blobContainer.SaveAsync(blobName, bytes);
        }

        public async Task<byte[]> GetCvAsync(Candidate candidate)
        {
            var blobName = candidate.Name + "-" + candidate.LastName + "-CV";
            return await _blobContainer.GetAllBytesOrNullAsync(blobName);
        }


    }
}

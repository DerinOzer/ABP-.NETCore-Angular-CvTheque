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
        /// <summary>
        /// This method is used to upload a CV to a candidate profile.
        /// </summary>
        /// <param name="id">Candidate Id</param>
        /// <param name="file"></param>
        /// <returns></returns>
        Task UploadCvAsync(Guid id, IFormFile file);
        /// <summary>
        /// This method is used to download a candidate's CV if their profile contains one.
        /// </summary>
        /// <param name="id">Candidate Id </param>
        /// <returns></returns>
        Task<FileResult> GetCvAsync(Guid id);
    }
}

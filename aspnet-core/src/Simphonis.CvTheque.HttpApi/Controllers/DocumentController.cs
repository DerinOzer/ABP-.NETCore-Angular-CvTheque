using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simphonis.CvTheque.Documents;
using Volo.Abp.AspNetCore.Mvc;

namespace Simphonis.CvTheque.Controllers
{
    public class DocumentController :AbpController 
    {
        private readonly ICvAppService _cvAppService;

        public DocumentController(ICvAppService cvAppService)
        {
            _cvAppService = cvAppService;
        }

        /*[HttpGet]
        [Route("download/{documentName}")]
        public async Task<IActionResult> DownloadAsync(string documentName)
        {
            var CvDto = await _cvAppService.GetCvAsync(new GetCvDto { Name = documentName });
            return File(CvDto.Content, "application/octet-stream",CvDto.Name);
        }*/

    }
}

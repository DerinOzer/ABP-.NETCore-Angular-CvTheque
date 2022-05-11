using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task SaveCvAsync(SaveCvDto input)
        {
            await _cvContainer.SaveAsync(input.Name, input.Content, true);
        }

        public async Task<CvDto> GetCvAsync(GetCvDto input)
        {
            var cv = await _cvContainer.GetAllBytesAsync(input.Name);

            return new CvDto
            {
                Name = input.Name,
                Content = cv,
            };
        }
    }
}

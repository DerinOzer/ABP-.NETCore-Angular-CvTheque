using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Content;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Simphonis.CvTheque.Documents
{
    public class Cv
    {
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public string Name { get; set; }

        public Cv(long fileSize, string fileType, string name)
        {
            FileSize = fileSize;
            FileType = fileType;
            Name = name;
        }
    }
}

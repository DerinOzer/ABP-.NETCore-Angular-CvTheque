using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Simphonis.CvTheque.Documents
{
    public class Cv
    {
        public byte[] Content { get; set; }
        public string Name{get;set;}
    }
}

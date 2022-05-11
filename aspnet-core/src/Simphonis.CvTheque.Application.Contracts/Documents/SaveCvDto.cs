using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Simphonis.CvTheque.Documents
{
    public class SaveCvDto
    {
        public long FileSize { get; set; }
        public string FileType { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

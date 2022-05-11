using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Simphonis.CvTheque.Documents
{
    public class GetCvDto
    {
        [Required]
        public string Name { get; set; }
    }
}

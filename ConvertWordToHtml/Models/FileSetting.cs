using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ConvertWordToHtml.Models
{
    public class FileSetting
    {
       [DisplayName("Upload File")]
        public string DocumentPath { get; set; }

        public HttpPostedFileBase DocumentFile { get; set; }
    }
}
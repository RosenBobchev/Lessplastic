using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models
{
    public class Education
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string AdditionalContent { get; set; }

        public string AdditionalContentImage { get; set; }

        public string DownloadLink { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Views { get; set; }
    }
}
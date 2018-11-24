using System;
using System.ComponentModel.DataAnnotations;

namespace Lessplastic.Models.ViewModels.Articles
{
    public class ArticleViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string ArticleImage { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ContentImage { get; set; }

        [Required]
        public string Type { get; set; }

        public string AdditionalContent { get; set; }

        public string AdditionalContentImage { get; set; }
    }
}
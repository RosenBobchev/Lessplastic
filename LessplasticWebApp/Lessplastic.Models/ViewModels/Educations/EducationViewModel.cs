using System.ComponentModel.DataAnnotations;

namespace Lessplastic.Models.ViewModels.Educations
{
    public class EducationViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string AdditionalContent { get; set; }

        public string AdditionalContentImage { get; set; }

        public string DownloadLink { get; set; }

        public int Views { get; set; }
    }
}
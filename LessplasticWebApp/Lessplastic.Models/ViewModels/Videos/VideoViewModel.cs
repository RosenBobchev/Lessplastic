using System.ComponentModel.DataAnnotations;

namespace Lessplastic.Models.ViewModels.Videos
{
    public class VideoViewModel
    {
        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        public string YoutubeLink { get; set; }
    }
}
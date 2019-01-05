using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lessplastic.Models.ViewModels.Videos
{
    public class UpdateDeleteVideoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string YoutubeLink { get; set; }

        public string DisabledValue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Videos
{
    public class AllVideosViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string YoutubeLink { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Videos
{
    public class UpdateDeleteVideoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string YoutubeLink { get; set; }

        public string DisabledValue { get; set; }
    }
}

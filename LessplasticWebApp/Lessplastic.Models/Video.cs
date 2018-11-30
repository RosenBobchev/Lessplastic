using System;

namespace Lessplastic.Models
{
    public class Video
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string YoutubeLink { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
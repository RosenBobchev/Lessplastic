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

        public string ShortDescription
        {
            get
            {
                if (this.Description?.Length > 25)
                {
                    return this.Description.Substring(0, 25) + "...";
                }
                else
                {
                    return this.Description;
                }
            }
        }

        public string YoutubeLink { get; set; }
        
        public DateTime CreatedOn { get; set; }
    }
}
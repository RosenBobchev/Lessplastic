using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Home
{
    public class IndexVideoViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                if (this.Content?.Length > 50)
                {
                    return this.Content.Substring(0, 50) + "...";
                }
                else
                {
                    return this.Content;
                }
            }
        }

        public string YoutubeLink { get; set; }
    }
}

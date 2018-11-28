namespace Lessplastic.Models.ViewModels.Educations
{
    public class AllEducationsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ShortContent
        {
            get
            {
                if (this.Content?.Length > 150)
                {
                    return this.Content.Substring(0, 150) + "...";
                }
                else
                {
                    return this.Content;
                }
            }
        }
        
        public string ImageUrl { get; set; }

        public string AdditionalContent { get; set; }

        public string ShortAdditionalContent
        {
            get
            {
                if (this.AdditionalContent?.Length > 150)
                {
                    return this.AdditionalContent.Substring(0, 150) + "...";
                }
                else
                {
                    return this.AdditionalContent;
                }
            }
        }


        public string AdditionalContentImage { get; set; }

        public string DownloadLink { get; set; }
    }
}

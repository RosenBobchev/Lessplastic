namespace Lessplastic.Models.ViewModels.Articles
{
    public class AllArticleViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public string ArticleImage { get; set; }
        
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
    }
}

using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Articles;

namespace Lessplastic.Services.Contracts
{
    public interface IArticleService
    {
        Article GetArticle(int id);

        Article[] GetArticles();
        
        bool CreateArticle(ArticleViewModel model);

        bool EditArticle(Article article, UpdateDeleteArticleViewModel model);

        void DeleteArticle(Article article);

        void IncrementViews(Article article);
    }
}

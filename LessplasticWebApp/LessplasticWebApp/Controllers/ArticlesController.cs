using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Articles;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Controllers
{
    public class ArticlesController : Controller
    {
        private IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public IActionResult Details(int id)
        {
            var comments = this.articleService.GetComments(id);

            var article = this.articleService.GetArticle(id);

            if (article == null)
            {
                return this.Redirect("/");
            }

            this.articleService.IncrementViews(article);

            var model = new DetailsArticleViewModel
            {
                Id = article.Id,
                Title = article.Title,
                ArticleImage = article.ArticleImage,
                Content = article.Content,
                ContentImage = article.ContentImage,
                Type = article.Type.ToString(),
                AdditionalContent = article.AdditionalContent,
                AdditionalContentImage = article.AdditionalContentImage,
                CreatedOn = article.CreatedOn,
                Views = article.Views,
                Comments = comments,
            };

            return this.View(model);
        }

        public IActionResult All()
        {
            var articles = this.articleService.GetArticles();

            var model = articles.Select(x => new AllArticleViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ArticleImage = x.ArticleImage,
                Content = x.Content,
            });

            return this.View(model);
        }
    }
}
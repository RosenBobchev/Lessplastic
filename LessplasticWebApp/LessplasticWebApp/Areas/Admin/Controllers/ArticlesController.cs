using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Articles;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticlesController : Controller
    {
        private IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(ArticleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            this.articleService.CreateArticle(model);

            return this.Redirect("/");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Details(int id)
        {
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
                Comments = article.Comments
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var article = this.articleService.GetArticle(id);

            if (article == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeleteArticleViewModel
            {
                Id = article.Id,
                Title = article.Title,
                ArticleImage = article.ArticleImage,
                Content = article.Content,
                ContentImage = article.ContentImage,
                Type = article.Type.ToString(),
                AdditionalContent = article.AdditionalContent,
                AdditionalContentImage = article.AdditionalContentImage,
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(UpdateDeleteArticleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var article = this.articleService.GetArticle(model.Id);

            if (article == null)
            {
                return this.Redirect("/");
            }

            this.articleService.EditArticle(article, model);

            return this.Redirect("/Admin/Articles/Details?id=" + model.Id);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var article = this.articleService.GetArticle(id);

            if (article == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeleteArticleViewModel
            {
                Id = article.Id,
                Title = article.Title,
                ArticleImage = article.ArticleImage,
                Content = article.Content,
                ContentImage = article.ContentImage,
                Type = article.Type.ToString(),
                AdditionalContent = article.AdditionalContent,
                AdditionalContentImage = article.AdditionalContentImage,
                DisabledValue = "disabled",
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteAction(int id)
        {
            var article = this.articleService.GetArticle(id);

            if (article == null)
            {
                return this.Redirect("/");
            }

            this.articleService.DeleteArticle(article);

            return this.Redirect("/");
        }
    }
}
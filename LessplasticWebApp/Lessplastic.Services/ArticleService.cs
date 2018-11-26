using Lessplastic.Models;
using Lessplastic.Models.Enums;
using Lessplastic.Models.ViewModels.Articles;
using Lessplastic.Services.Contracts;
using LessplasticWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Lessplastic.Services
{
    public class ArticleService : IArticleService
    {
        private ApplicationDbContext context;

        public ArticleService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool CreateArticle(ArticleViewModel model)
        {
            if (!Enum.TryParse(model.Type, out ArticleType articleType))
            {
                return false;
            }

            var article = new Article
            {
                Title = model.Title,
                ArticleImage = model.ArticleImage,
                Content = model.Content,
                ContentImage = model.ContentImage,
                Type = articleType,
                AdditionalContent = model.AdditionalContent,
                AdditionalContentImage = model.AdditionalContentImage,
                CreatedOn = DateTime.Now,
                Views = 0,
            };
            this.context.Articles.Add(article);
            this.context.SaveChanges();

            return true;
        }

        public void IncrementViews(Article article)
        {
            article.Views += 1;
            this.context.SaveChanges();
        }

        public void DeleteArticle(Article article)
        {
            this.context.Articles.Remove(article);
            this.context.SaveChanges();
        }

        public bool EditArticle(Article article, UpdateDeleteArticleViewModel model)
        {
            if (!Enum.TryParse(model.Type, out ArticleType articleType))
            {
                return false;
            }

            article.Title = model.Title;
            article.ArticleImage = model.ArticleImage;
            article.Content = model.Content;
            article.ContentImage = model.ContentImage;
            article.Type = articleType;
            article.AdditionalContent = model.AdditionalContent;
            article.AdditionalContentImage = model.AdditionalContentImage;

            this.context.SaveChanges();
            return true;
        }

        public Article GetArticle(int id)
        {
            var article = this.context.Articles.Include(x => x.Comments).FirstOrDefault(a => a.Id == id);

            return article;
        }

        public Article[] GetArticles()
        {
            var articles = this.context.Articles.Include(x => x.Comments).ToArray();

            return articles;
        }
    }
}

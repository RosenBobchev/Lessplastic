using Lessplastic.Models;
using Lessplastic.Models.Enums;
using Lessplastic.Models.ViewModels.Articles;
using LessplasticWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Lessplastic.Services.Tests
{
    public class ArticleServiceTests
    {
        [Fact]
        public void CreateArticleShouldCreateArticle()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new ArticleService(dbContext);

            var model = new ArticleViewModel
            {
                Title = "Title",
                ArticleImage = "Something",
                AdditionalContent = "Something",
                AdditionalContentImage = "Something",
                Content = "Something",
                ContentImage = "Something",
                Type = "Kids",
            };

            var article = service.CreateArticle(model);

            Assert.True(article);
        }

        [Fact]
        public void CreateArticleShouldReturnFalseForWrongArticleType()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new ArticleService(dbContext);

            var model = new ArticleViewModel
            {
                Title = "Title",
                ArticleImage = "Something",
                AdditionalContent = "Something",
                AdditionalContentImage = "Something",
                Content = "Something",
                ContentImage = "Something",
                Type = "Normal",
            };

            var article = service.CreateArticle(model);

            Assert.False(article);
        }

        [Fact]
        public void IncrementViewsShouldIncreaseCounterOnViews()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new ArticleService(dbContext);

            dbContext.Articles.Add(new Article());
            dbContext.SaveChanges();

            var article = dbContext.Articles.First();

            service.IncrementViews(article);
            service.IncrementViews(article);

            Assert.Equal(2, article.Views);
        }

        [Fact]
        public void DeleteArticleShouldDeleteAnArticleFromDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new ArticleService(dbContext);

            dbContext.Articles.Add(new Article());
            dbContext.Articles.Add(new Article());
            dbContext.Articles.Add(new Article());
            dbContext.SaveChanges();

            var article = dbContext.Articles.First();

            service.DeleteArticle(article);

            Assert.Equal(2, dbContext.Articles.Count());
        }

        [Fact]
        public void EditArticleShoudEditOneOrMorePropertiesInArticle()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new ArticleService(dbContext);

            var model = new UpdateDeleteArticleViewModel
            {
                Type = "Regular"
            };

            var article = new Article
            {
                Type = ArticleType.Kids
            };

            dbContext.Articles.Add(article);
            dbContext.SaveChanges();

            var articleToEdit = dbContext.Articles.First();

            service.EditArticle(articleToEdit, model);

            Assert.Equal("Regular", articleToEdit.Type.ToString());
        }

        [Fact]
        public void GetArticleShouldReturnAnArticleById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Tests").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new ArticleService(dbContext);

            var article = new Article
            {
                Title = "Test"
            };

            dbContext.Articles.Add(article);
            dbContext.SaveChanges();

            var returnedArticle = service.GetArticle(1);

            Assert.Equal(article.Title, returnedArticle.Title);
        }
    }
}

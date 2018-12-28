using Lessplastic.Models;
using Lessplastic.Models.Enums;
using LessplasticWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lessplastic.Services.Tests
{
    public class HomeServiceTests
    {
        [Fact]
        public void NewArticlesShouldReturnTop5NewArticlesFromTypeRegularOrScience()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_NewArticles").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new HomeService(dbContext);

            var firstArticle = new Article
            {
                Type = ArticleType.Regular
            };
            var secondArticle = new Article
            {
                Type = ArticleType.Science
            };
            var thirdArticle = new Article
            {
                Type = ArticleType.Regular
            };
            var fourthArticle = new Article
            {
                Type = ArticleType.Science
            };
            var fifthArticle = new Article
            {
                Type = ArticleType.Science
            };
            var sixthArticle = new Article
            {
                Type = ArticleType.Regular
            };
            var seventhArticle = new Article
            {
                Type = ArticleType.Regular
            };

            dbContext.Articles.Add(firstArticle);
            dbContext.Articles.Add(secondArticle);
            dbContext.Articles.Add(thirdArticle);
            dbContext.Articles.Add(fourthArticle);
            dbContext.Articles.Add(fifthArticle);
            dbContext.Articles.Add(sixthArticle);
            dbContext.Articles.Add(seventhArticle);
            dbContext.SaveChanges();

            var articles = service.NewArticles();

            Assert.Equal(5, articles.Length);
        }

        [Fact]
        public void TopRegularArticlesShouldReturn5ArticlesWithMostViewsFromTypeRegular()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_NewArticles").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new HomeService(dbContext);

            var firstArticle = new Article
            {
                Type = ArticleType.Regular
            };
            var secondArticle = new Article
            {
                Type = ArticleType.Regular
            };
            var thirdArticle = new Article
            {
                Type = ArticleType.Regular
            };
            var fourthArticle = new Article
            {
                Type = ArticleType.Regular
            };
            var fifthArticle = new Article
            {
                Type = ArticleType.Science
            };
            var sixthArticle = new Article
            {
                Type = ArticleType.Regular
            };
            var seventhArticle = new Article
            {
                Type = ArticleType.Regular
            };

            dbContext.Articles.Add(firstArticle);
            dbContext.Articles.Add(secondArticle);
            dbContext.Articles.Add(thirdArticle);
            dbContext.Articles.Add(fourthArticle);
            dbContext.Articles.Add(fifthArticle);
            dbContext.Articles.Add(sixthArticle);
            dbContext.Articles.Add(seventhArticle);
            dbContext.SaveChanges();

            var articles = service.TopRegularArticles();

            Assert.Equal(5, articles.Length);
        }

        [Fact]
        public void TopScienceArticlesShouldReturn5ArticlesWithMostViewsFromTypeScience()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_NewArticles").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new HomeService(dbContext);

            var firstArticle = new Article
            {
                Type = ArticleType.Regular
            };
            var secondArticle = new Article
            {
                Type = ArticleType.Science
            };
            var thirdArticle = new Article
            {
                Type = ArticleType.Science
            };
            var fourthArticle = new Article
            {
                Type = ArticleType.Science
            };
            var fifthArticle = new Article
            {
                Type = ArticleType.Science
            };
            var sixthArticle = new Article
            {
                Type = ArticleType.Science
            };
            var seventhArticle = new Article
            {
                Type = ArticleType.Science
            };

            dbContext.Articles.Add(firstArticle);
            dbContext.Articles.Add(secondArticle);
            dbContext.Articles.Add(thirdArticle);
            dbContext.Articles.Add(fourthArticle);
            dbContext.Articles.Add(fifthArticle);
            dbContext.Articles.Add(sixthArticle);
            dbContext.Articles.Add(seventhArticle);
            dbContext.SaveChanges();

            var articles = service.TopScienceArticles();

            Assert.Equal(5, articles.Length);
        }

        [Fact]
        public void TopKidsArticleShouldReturn5ArticlesWithMostViewsFromTypeKids()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_NewArticles").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new HomeService(dbContext);

            var firstArticle = new Article
            {
                Type = ArticleType.Kids
            };
            var secondArticle = new Article
            {
                Type = ArticleType.Kids
            };
            var thirdArticle = new Article
            {
                Type = ArticleType.Kids
            };
            var fourthArticle = new Article
            {
                Type = ArticleType.Kids
            };
            var fifthArticle = new Article
            {
                Type = ArticleType.Kids
            };
            var sixthArticle = new Article
            {
                Type = ArticleType.Kids
            };
            var seventhArticle = new Article
            {
                Type = ArticleType.Science
            };

            dbContext.Articles.Add(firstArticle);
            dbContext.Articles.Add(secondArticle);
            dbContext.Articles.Add(thirdArticle);
            dbContext.Articles.Add(fourthArticle);
            dbContext.Articles.Add(fifthArticle);
            dbContext.Articles.Add(sixthArticle);
            dbContext.Articles.Add(seventhArticle);
            dbContext.SaveChanges();

            var articles = service.TopKidsArticles();

            Assert.Equal(5, articles.Length);
        }

        [Fact]
        public void TopEducationsSholdReturnTop5EducationsWithMostViews()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_NewArticles").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new HomeService(dbContext);

            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.Educations.Add(new Education());
            dbContext.SaveChanges();

            var educations = service.TopEducations();

            Assert.Equal(5, educations.Length);
        }

        [Fact]
        public void TopVideosShouldReturnTop5VideosWithMostViews()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_NewArticles").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new HomeService(dbContext);

            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.SaveChanges();

            var videos = service.TopVideos();

            Assert.Equal(5, videos.Length);
        }

        [Fact]
        public void TopEventsShouldReturnTop3EventsByDate()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_NewArticles").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new HomeService(dbContext);

            var firstEvent = new Event
            {
                CreatedOn = DateTime.Now
            };
            var secondEvent = new Event
            {
                CreatedOn = DateTime.Now
            };
            var thirdEvent = new Event
            {
                CreatedOn = DateTime.Now.AddYears(3)
            };
            var fourthEvent = new Event
            {
                CreatedOn = DateTime.Now.AddYears(3)
            };
            var fifthEvent = new Event
            {
                CreatedOn = DateTime.Now
            };
            var sixthEvent = new Event
            {
                CreatedOn = DateTime.Now.AddYears(3)
            };
            var seventhEvent = new Event
            {
                CreatedOn = DateTime.Now.AddYears(3)
            };
            var eighthEvent = new Event
            {
                CreatedOn = DateTime.Now
            };

            dbContext.Events.Add(firstEvent);
            dbContext.Events.Add(secondEvent);
            dbContext.Events.Add(thirdEvent);
            dbContext.Events.Add(fourthEvent);
            dbContext.Events.Add(fifthEvent);
            dbContext.Events.Add(sixthEvent);
            dbContext.Events.Add(seventhEvent);
            dbContext.Events.Add(eighthEvent);
            dbContext.SaveChanges();

            var events = service.TopEvents();

            Assert.Equal(3, events.Length);
        }

        [Fact]
        public void TopPollShouldReturnTheNewestPollCreated()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_NewArticles").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new HomeService(dbContext);

            var firstPoll = new Poll
            {
                Title = "first",
                CreatedOn = DateTime.Now.AddDays(2)
            };
            var secondPoll = new Poll
            {
                Title = "second",
                CreatedOn = DateTime.Now
            };
            var thirdPoll = new Poll
            {
                Title = "third",
                CreatedOn = DateTime.Now
            };

            dbContext.Polls.Add(firstPoll);
            dbContext.Polls.Add(secondPoll);
            dbContext.Polls.Add(thirdPoll);
            dbContext.SaveChanges();

            var poll = service.TopPoll();

            Assert.Equal("first", poll.Title);
        }
    }
}

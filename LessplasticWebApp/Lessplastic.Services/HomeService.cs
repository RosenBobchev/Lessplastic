using Lessplastic.Models;
using Lessplastic.Models.Enums;
using Lessplastic.Models.ViewModels.Home;
using Lessplastic.Services.Contracts;
using LessplasticWebApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lessplastic.Services
{
    public class HomeService : IHomeService
    {
        private ApplicationDbContext context;

        public HomeService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Article[] NewArticles()
        {
            var articles = this.context.Articles
                .Where(x => x.Type == ArticleType.Regular || x.Type == ArticleType.Science)
                .OrderByDescending(x => x.CreatedOn).Take(5).ToArray();

            return articles;
        }

        public Article[] TopRegularArticles()
        {
            var articles = this.context.Articles
                .Where(x => x.Type == ArticleType.Regular)
                .OrderByDescending(x => x.Views).Take(5).ToArray();

            return articles;
        }
        public Article[] TopScienceArticles()
        {
            var articles = this.context.Articles
                .Where(x => x.Type == ArticleType.Science)
                .OrderByDescending(x => x.Views).Take(5).ToArray();

            return articles;
        }
        public Article[] TopKidsArticles()
        {
            var articles = this.context.Articles
                .Where(x => x.Type == ArticleType.Kids)
                .OrderByDescending(x => x.Views).Take(5).ToArray();

            return articles;
        }

        public Education[] TopEducations()
        {
            var articles = this.context.Educations
                .OrderByDescending(x => x.Views).Take(5).ToArray();

            return articles;
        }

        public Video[] TopVideos()
        {
            var videos = this.context.Videos.OrderByDescending(x => x.CreatedOn).Take(5).ToArray();

            return videos;
        }
    }
}

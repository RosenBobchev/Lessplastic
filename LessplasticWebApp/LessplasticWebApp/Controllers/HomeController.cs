using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LessplasticWebApp.Models;
using Lessplastic.Services.Contracts;
using Lessplastic.Models.ViewModels.Home;

namespace LessplasticWebApp.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        public IActionResult Index()
        {
            var newArticlesModel = this.homeService.NewArticles();
            var topRegularArticles = this.homeService.TopRegularArticles();
            var topScienceArticles = this.homeService.TopScienceArticles();
            var topKidsArticles = this.homeService.TopKidsArticles();
            var newVideosModel = this.homeService.TopVideos();
            var topEducationsModel = this.homeService.TopEducations();

            var newArticles = newArticlesModel.Select(x => new IndexViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                TitleImage = x.ArticleImage,
            }).ToList();

            var regularTopArticles = topRegularArticles.Select(x => new IndexViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                TitleImage = x.ArticleImage,
            }).ToList();

            var scienceTopArticles = topScienceArticles.Select(x => new IndexViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                TitleImage = x.ArticleImage,
            }).ToList();

            var kidsTopArticles = topKidsArticles.Select(x => new IndexViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                TitleImage = x.ArticleImage,
            }).ToList();

            var topEducations = topEducationsModel.Select(x => new IndexViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                TitleImage = x.ImageUrl,
            }).ToList();

            var newVideos = newVideosModel.Select(x => new IndexVideoViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Description,
                YoutubeLink = x.YoutubeLink,
            }).ToList();

            var model = new CollectionIndexViewModel
            {
                NewArticles = newArticles,
                TopRegularArticles = regularTopArticles,
                TopKidsArticles = kidsTopArticles,
                TopScienceArticles = scienceTopArticles,
                NewVideos = newVideos,
                NewEducations = topEducations,
            };

            return this.View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Partnership()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

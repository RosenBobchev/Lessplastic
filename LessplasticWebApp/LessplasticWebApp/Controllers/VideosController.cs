using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lessplastic.Models.ViewModels.Videos;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LessplasticWebApp.Controllers
{
    public class VideosController : Controller
    {
        private IVideoService videoService;

        public VideosController(IVideoService videoService)
        {
            this.videoService = videoService;
        }
        
        public IActionResult All()
        {
            var videos = this.videoService.GetVideos();

            var model = videos.Select(x => new AllVideosViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                YoutubeLink = x.YoutubeLink,
                CreatedOn = x.CreatedOn,
            }).OrderByDescending(x => x.CreatedOn).ToList();

            return this.View(model);
        }
        
        public IActionResult Details(int id)
        {
            var video = this.videoService.GetVideo(id);

            if (video == null)
            {
                return this.Redirect("/");
            }

            var model = new DetailsVideoViewModel
            {
                Id = video.Id,
                Title = video.Title,
                Description = video.Description,
                YoutubeLink = video.YoutubeLink,
            };

            return this.View(model);
        }
    }
}
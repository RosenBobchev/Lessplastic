using Lessplastic.Models.ViewModels.Videos;
using Lessplastic.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LessplasticWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VideosController : Controller
    {
        private IVideoService videoService;

        public VideosController(IVideoService videoService)
        {
            this.videoService = videoService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(VideoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var id = this.videoService.CreateVideo(model);

            return this.Redirect("/Admin/Videos/Details?id=" + id);
        }

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var video = this.videoService.GetVideo(id);

            if (video == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeleteVideoViewModel
            {
                Id = video.Id,
                Title = video.Title,
                Description = video.Description,
                YoutubeLink = video.YoutubeLink,
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(UpdateDeleteVideoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var video = this.videoService.GetVideo(model.Id);

            if (video == null)
            {
                return this.Redirect("/");
            }

            this.videoService.EditVideo(video, model);

            return this.Redirect("/Admin/Videos/Details?id=" + model.Id);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var video = this.videoService.GetVideo(id);

            if (video == null)
            {
                return this.Redirect("/");
            }

            var model = new UpdateDeleteVideoViewModel
            {
                Id = video.Id,
                Title = video.Title,
                Description = video.Description,
                YoutubeLink = video.YoutubeLink,
                DisabledValue = "disabled",
            };

            return this.View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult DeleteAction(int id)
        {
            var video = this.videoService.GetVideo(id);

            if (video == null)
            {
                return this.Redirect("/");
            }

            this.videoService.DeleteVideo(video);

            return this.Redirect("/");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult All()
        {
            var videos = this.videoService.GetVideos();

            var model = videos.Select(x => new AllVideosViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                YoutubeLink = x.YoutubeLink,
            }).ToArray();

            return this.View(model);
        }
    }
}
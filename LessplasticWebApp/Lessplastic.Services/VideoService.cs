using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Videos;
using Lessplastic.Services.Contracts;
using LessplasticWebApp.Data;
using System;
using System.Linq;

namespace Lessplastic.Services
{
    public class VideoService : IVideoService
    {
        private ApplicationDbContext context;

        public VideoService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int CreateVideo(VideoViewModel model)
        {
            var linkId = model.YoutubeLink.IndexOf('=');
            var youtubeLink = model.YoutubeLink.Substring(linkId + 1);

            var video = new Video
            {
                Title = model.Title,
                Description = model.Description,
                YoutubeLink = youtubeLink,
            };

            this.context.Videos.Add(video);
            this.context.SaveChanges();

            var id = video.Id;

            return id;
        }

        public void DeleteVideo(Video video)
        {
            this.context.Videos.Remove(video);
            this.context.SaveChanges();
        }

        public void EditVideo(Video video, UpdateDeleteVideoViewModel model)
        {
            video.Title = model.Title;
            video.Description = model.Description;
            video.YoutubeLink = model.YoutubeLink;

            this.context.SaveChanges();
        }

        public Video GetVideo(int id)
        {
            var video = this.context.Videos.FirstOrDefault(v => v.Id == id);

            return video;
        }

        public Video[] GetVideos()
        {
            var videos = this.context.Videos.ToArray();

            return videos;
        }
    }
}

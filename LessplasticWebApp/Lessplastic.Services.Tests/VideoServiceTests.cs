using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Videos;
using LessplasticWebApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Lessplastic.Services.Tests
{
    public class VideoServiceTests
    {
        [Fact]
        public void CreateVidoeShouldCreateVideoAndReturnItsId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_CreatingVideos").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new VideoService(dbContext);

            var model = new VideoViewModel
            {
                Title = "Title",
                Description = "something",
                YoutubeLink = "something",
            };

            var video = service.CreateVideo(model);

            Assert.Equal(1, video);
        }

        [Fact]
        public void DeleteVideoShouldDeleteVideoFromDatabase()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_DeletingVideos").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new VideoService(dbContext);

            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.SaveChanges();

            var video = dbContext.Videos.First();

            service.DeleteVideo(video);

            Assert.Equal(2, dbContext.Videos.Count());
        }

        [Fact]
        public void EditVideoShoudEditOneOrMorePropertiesInVideo()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Videos").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new VideoService(dbContext);

            var model = new UpdateDeleteVideoViewModel
            {
                Title = "Edited",
            };

            var video = new Video
            {
                Title = "New",
            };

            dbContext.Videos.Add(video);
            dbContext.SaveChanges();

            var videoToEdit = dbContext.Videos.First();

            service.EditVideo(videoToEdit, model);

            Assert.Equal("Edited", videoToEdit.Title);
        }

        [Fact]
        public void GetVideoShouldReturnVideoById()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Videos").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new VideoService(dbContext);

            var video = new Video
            {
                Title = "Test"
            };

            dbContext.Videos.Add(video);
            dbContext.SaveChanges();

            var returnedVideo = service.GetVideo(1);

            Assert.Equal(video.Title, returnedVideo.Title);
        }

        [Fact]
        public void GetVideosShouldReturnAllVideos()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("Database_For_Videos").Options;
            var dbContext = new ApplicationDbContext(options);
            var service = new VideoService(dbContext);

            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.Videos.Add(new Video());
            dbContext.SaveChanges();

            var videos = service.GetVideos();

            Assert.Equal(5, videos.Length);
        }
    }
}

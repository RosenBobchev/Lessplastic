using Lessplastic.Models;
using Lessplastic.Models.ViewModels.Videos;

namespace Lessplastic.Services.Contracts
{
    public interface IVideoService
    {
        Video GetVideo(int id);

        Video[] GetVideos();

        int CreateVideo(VideoViewModel model);

        void EditVideo(Video video, UpdateDeleteVideoViewModel model);

        void DeleteVideo(Video video);
    }
}

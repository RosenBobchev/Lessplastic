using Lessplastic.Models;

namespace Lessplastic.Services.Contracts
{
    public interface IHomeService
    {
        Article[] NewArticles();

        Article[] TopRegularArticles();

        Article[] TopScienceArticles();

        Article[] TopKidsArticles();

        Video[] TopVideos();

        Education[] TopEducations();

        Event[] TopEvents(string username);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Home
{
    public class CollectionIndexViewModel
    {
        public IEnumerable<IndexViewModel> NewArticles { get; set; }

        public IEnumerable<IndexViewModel> TopRegularArticles { get; set; }

        public IEnumerable<IndexViewModel> TopKidsArticles { get; set; }

        public IEnumerable<IndexViewModel> TopScienceArticles { get; set; }

        public IEnumerable<IndexVideoViewModel> NewVideos { get; set; }

        public IEnumerable<IndexViewModel> NewEducations { get; set; }
    }
}

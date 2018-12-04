using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Pools
{
    public class AllPoolViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public ICollection<PoolsUsers> Users { get; set; }

        public ICollection<PoolsAnswers> Answers { get; set; }
    }
}

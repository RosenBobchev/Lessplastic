using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Home
{
    public class IndexPollViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public ICollection<PollsUsers> Users { get; set; }
    }
}
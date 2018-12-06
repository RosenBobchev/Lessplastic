using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Polls
{
    public class AllPollViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public ICollection<PollsUsers> Users { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}

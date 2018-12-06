using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models
{
    public class Poll
    {
        public Poll()
        {
            this.Users = new HashSet<PollsUsers>();
            this.Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public ICollection<PollsUsers> Users { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
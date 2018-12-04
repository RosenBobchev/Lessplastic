using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models
{
    public class Pool
    {
        public Pool()
        {
            this.Users = new HashSet<PoolsUsers>();
            this.Answers = new HashSet<PoolsAnswers>();
        }

        public int Id { get; set; }

        public string Title { get; set; }
        
        public ICollection<PoolsUsers> Users { get; set; }

        public ICollection<PoolsAnswers> Answers { get; set; }
    }
}
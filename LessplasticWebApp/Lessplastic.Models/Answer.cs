using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models
{
    public class Answer
    {
        public Answer()
        {
            this.Pools = new HashSet<PoolsAnswers>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<PoolsAnswers> Pools { get; set; }

    }
}

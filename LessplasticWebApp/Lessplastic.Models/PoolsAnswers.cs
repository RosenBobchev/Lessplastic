using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models
{
    public class PoolsAnswers
    {
        public int AnswerId { get; set; }

        public Answer Answer { get; set; }

        public int PoolId { get; set; }

        public Pool Pool { get; set; }
    }
}

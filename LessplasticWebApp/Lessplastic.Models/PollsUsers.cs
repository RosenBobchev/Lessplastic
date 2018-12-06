using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models
{
    public class PollsUsers
    {
        public string LessplasticUserId { get; set; }

        public LessplasticUser LessplasticUser { get; set; }

        public int PollId { get; set; }

        public Poll Poll { get; set; }
    }
}

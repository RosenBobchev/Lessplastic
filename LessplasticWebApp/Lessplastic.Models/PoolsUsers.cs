using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models
{
    public class PoolsUsers
    {
        public string LessplasticUserId { get; set; }

        public LessplasticUser LessplasticUser { get; set; }

        public int PoolId { get; set; }

        public Pool Pool { get; set; }
    }
}

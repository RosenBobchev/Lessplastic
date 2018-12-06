using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Lessplastic.Models
{
    public class LessplasticUser : IdentityUser
    {
        public LessplasticUser()
        {
            this.Events = new HashSet<UserEvents>();
            this.Pools = new HashSet<PollsUsers>();
        }

        public int? TownId { get; set; }

        public Town Town { get; set; }

        public string FullName { get; set; }

        public ICollection<UserEvents> Events { get; set; }

        public ICollection<PollsUsers> Pools { get; set; }
    }
}
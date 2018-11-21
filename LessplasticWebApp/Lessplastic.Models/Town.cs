using System.Collections.Generic;

namespace Lessplastic.Models
{
    public class Town
    {
        public Town()
        {
            this.Events = new HashSet<EventTowns>();
            this.Users = new HashSet<LessplasticUser>();
        }

        public int Id { get; set; }

        public string TownName { get; set; }

        public string Country { get; set; }

        public ICollection<EventTowns> Events { get; set; }

        public ICollection<LessplasticUser> Users { get; set; }
    }
}
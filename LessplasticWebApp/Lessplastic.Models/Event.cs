using System;
using System.Collections.Generic;

namespace Lessplastic.Models
{
    public class Event
    {
        public Event()
        {
            this.Participants = new HashSet<UserEvents>();
            this.Towns = new HashSet<EventTowns>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime EventDate { get; set; }

        public ICollection<UserEvents> Participants { get; set; }

        public ICollection<EventTowns> Towns { get; set; }
    }
}
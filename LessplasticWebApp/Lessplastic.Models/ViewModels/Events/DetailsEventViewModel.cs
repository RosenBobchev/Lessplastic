using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Events
{
    public class DetailsEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime EventDate { get; set; }

        public ICollection<EventTowns> Towns { get; set; }

        public ICollection<UserEvents> Participants { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Events
{
    public class EventViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Towns { get; set; }

        public DateTime EventDate { get; set; }
    }
}

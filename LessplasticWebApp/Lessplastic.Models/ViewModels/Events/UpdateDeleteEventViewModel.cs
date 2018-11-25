using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Events
{
    public class UpdateDeleteEventViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime EventDate { get; set; }

        public string DisabledValue { get; set; }
    }
}

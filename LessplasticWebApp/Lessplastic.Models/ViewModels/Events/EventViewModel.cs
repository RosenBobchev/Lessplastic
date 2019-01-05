using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lessplastic.Models.ViewModels.Events
{
    public class EventViewModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Towns { get; set; }

        [Required]
        public DateTime EventDate { get; set; }
    }
}

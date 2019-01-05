using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lessplastic.Models.ViewModels.Polls
{
    public class UpdateDeletePollViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string DisabledValue { get; set; }
    }
}

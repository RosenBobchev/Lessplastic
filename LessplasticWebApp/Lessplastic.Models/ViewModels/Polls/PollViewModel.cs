using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lessplastic.Models.ViewModels.Polls
{
    public class PollViewModel
    {
        [Required]
        [StringLength(30)]
        public string Title { get; set; }

        [Required]
        public string Answers { get; set; }
    }
}

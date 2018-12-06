using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Polls
{
    public class UpdateDeletePollViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string DisabledValue { get; set; }
    }
}

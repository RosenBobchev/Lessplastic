using System;
using System.Collections.Generic;
using System.Text;

namespace Lessplastic.Models.ViewModels.Events
{
    public class AllEventsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortContent
        {
            get
            {
                if (this.Description?.Length > 50)
                {
                    return this.Description.Substring(0, 50) + "...";
                }
                else
                {
                    return this.Description;
                }
            }
        }
    }
}

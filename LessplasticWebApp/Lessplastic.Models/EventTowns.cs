namespace Lessplastic.Models
{
    public class EventTowns
    {
        public int EventId { get; set; }

        public Event Event { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }
    }
}
namespace Lessplastic.Models
{
    public class UserEvents
    {
        public string LessplasticUserId { get; set; }

        public LessplasticUser LessplasticUser { get; set; }

        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
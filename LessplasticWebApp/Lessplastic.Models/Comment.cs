using System;

namespace Lessplastic.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string LessplasticUserId { get; set; }

        public LessplasticUser LessplasticUser { get; set; }

        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }
    }
}
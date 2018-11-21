using Lessplastic.Models.Enums;
using System;
using System.Collections.Generic;

namespace Lessplastic.Models
{
    public class Article
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ArticleImage { get; set; }

        public string Content { get; set; }

        public string ContentImage { get; set; }

        public string AdditionalContent { get; set; }

        public string AdditionalContentImage { get; set; }

        public ArticleType Type { get; set; }

        public DateTime CreatedOn { get; set; }

        public int Views { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
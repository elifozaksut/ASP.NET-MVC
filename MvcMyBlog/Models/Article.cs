using System;
using System.Collections.Generic;

namespace Models
{
    public class Article
    {
        public int ID { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Photo { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
        
    }
}
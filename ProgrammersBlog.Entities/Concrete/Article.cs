using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Article:EntityBase, IEntity // EntityBase'den türüyorsun ve IEntity implemente ediyorsun.
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Thumbnail { get; set; }
        public DateTime Date { get; set; }
        public int ViewCount { get; set; }
        public int CommentCount { get; set; }
        public string SeoAuthor { get; set; }
        public string SeoDescription { get; set; }
        public string SeoTags { get; set; }
        public int CategoryID { get; set; } // makale hangi kategoriye ait
        public Category Category { get; set; } // navigation property, kategoriye ulaşıp onun ismini, açıklamasını almak gibi ihtiyaçlarımız için.
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}

using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Comment:EntityBase, IEntity // EntityBase'den türüyorsun ve IEntity implemente ediyorsun.
    {
        public string Text { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }

    }
}

using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Role:EntityBase, IEntity // EntityBase'den türüyorsun ve IEntity implemente ediyorsun.
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } // aynı role sahip birden fazla user olabilir ve olacaktır.
    }
}

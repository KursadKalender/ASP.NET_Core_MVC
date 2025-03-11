using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Entities.Abstract
{
    public abstract class EntityBase 
    {
        // veri tabanına gidecek ortak değeleri tanımlayan sınıf.
        // neden abstract? --> Buradaki ortak değerlerin başka sınıflarda değişikliğe uğramasını isteyebiliriz.
        public virtual int ID { get; set; }

        public virtual DateTime CreatedDate { get; set; } = DateTime.Now; // virtual keyword ile override edilebilir hale getiriyoruz.

        public virtual DateTime ModifiedDate { get; set; } = DateTime.Now;

        public virtual bool IsDeleted { get; set; } = false;

        public virtual bool IsActive { get; set; } = true;

        public virtual string? CreatedByName { get; set; } = "Admin"; //nullable

        public virtual string? ModifiedByName { get; set; } = "Admin"; //nullable
        public virtual string? Note { get; set; }
    }
}

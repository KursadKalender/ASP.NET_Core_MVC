﻿using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Category:EntityBase, IEntity // EntityBase'den türüyorsun ve IEntity implemente ediyorsun.
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; } //ICollection arayüzü index değeri ile erişebilen aynı tip objelere ekleme, çıkarma, güncelleme gibi özellikler kazandırır.
    }
}

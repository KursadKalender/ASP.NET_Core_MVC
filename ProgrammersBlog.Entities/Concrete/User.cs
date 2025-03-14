﻿using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class User:EntityBase, IEntity // EntityBase'den türüyorsun ve IEntity implemente ediyorsun.
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; } // şifre hashlenerek tutulacağı için bir byte array olarak tutacağız.
        public string Username { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public ICollection<Article> Articles { get; set; } // bir kullanıcının birden fazla article'i olabilir.

    }
}

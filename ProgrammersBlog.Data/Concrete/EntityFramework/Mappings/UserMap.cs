using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID);
            builder.Property(u => u.ID).ValueGeneratedOnAdd();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique(); // Değer unique mi?
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.Username).HasMaxLength(20);
            builder.HasIndex(u => u.Username).IsUnique();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)");
            builder.Property(u => u.Description).HasMaxLength(500);
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u => u.Picture).IsRequired();
            builder.Property(u => u.Picture).HasMaxLength(250);
            builder.Property(u => u.CreatedByName).IsRequired(true);
            builder.Property(u => u.CreatedByName).HasMaxLength(50);
            builder.Property(u => u.ModifiedByName).IsRequired(true);
            builder.Property(u => u.ModifiedByName).HasMaxLength(50);
            builder.Property(u => u.CreatedDate).IsRequired(true);
            builder.Property(u => u.ModifiedDate).IsRequired(true);
            builder.Property(u => u.IsActive).IsRequired(true);
            builder.Property(u => u.IsDeleted).IsRequired(true);
            builder.Property(u => u.Note).HasMaxLength(500);
            builder.HasOne<Role>(u => u.Role).WithMany(u => u.Users).HasForeignKey(u => u.RoleID);
            builder.ToTable("Users");

            builder.HasData(new User
            {
                ID = 1,
                RoleID = 1,
                FirstName = "Kursad",
                LastName = "Kalender",
                Username = "kursadkalender",
                Email = "kursad@kalender.dev",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                ModifiedByName = "InitialCreate",
                ModifiedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                Description = "İlk Admin Kullanıcı",
                Note = "Admin Kullanıcı",
                PasswordHash = Encoding.ASCII.GetBytes("0192023a7bbd73250516f069df18b500"), //MD5 Hashed Password-Admin123,
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU" // Kullanıcı resmini çekmek için link
            });
        }
    }
}

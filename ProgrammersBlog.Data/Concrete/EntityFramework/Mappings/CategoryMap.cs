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
    public class CategoryMap : IEntityTypeConfiguration<Category> // Hangi sınıfı mapping yapayım?
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.ID); // ID alanı primary key oldu.
            builder.Property(c => c.ID).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired(true);
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.CreatedByName).IsRequired(true);
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedByName).IsRequired(true);
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired(true);
            builder.Property(c => c.ModifiedDate).IsRequired(true);
            builder.Property(c => c.IsActive).IsRequired(true);
            builder.Property(c => c.IsDeleted).IsRequired(true);
            builder.Property(c => c.Note).HasMaxLength(500);
            builder.ToTable("Categories"); // Tabloya isim vermemiz gerekiyor.

            builder.HasData(
                new Category
            {
                ID = 1,
                Name = "C#",
                Description = "C# Programlama Dili ile ilgili en güncel bilgiler.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                ModifiedByName = "InitialCreate",
                ModifiedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                Note = "C# Blog Kategorisi",
            },
                new Category
            {
                ID = 2,
                Name = "C++",
                Description = "C++ Programlama Dili ile ilgili en güncel bilgiler.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                ModifiedByName = "InitialCreate",
                ModifiedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                Note = "C++ Blog Kategorisi",
            },
                new Category
            {
                ID = 3,
                Name = "JavaScript",
                Description = "JavaScript Programlama Dili ile ilgili en güncel bilgiler.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                ModifiedByName = "InitialCreate",
                ModifiedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                Note = "JavaScript Blog Kategorisi",
            }
            );

        }
    }
}

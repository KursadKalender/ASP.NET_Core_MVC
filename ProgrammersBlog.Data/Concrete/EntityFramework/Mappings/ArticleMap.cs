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
    public class ArticleMap : IEntityTypeConfiguration<Article> //IEntityTypeConfiguration bize hangi entity'i map etmek istediğimizi sorar. Generic bir metottur. 
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.ID); // HasKey = primary key alanı var mı, varsa burada belirteceğiz.
            builder.Property(a => a.ID).ValueGeneratedOnAdd(); // ID'yi her seferinde arttır. 
            builder.Property(a => a.Title).HasMaxLength(100); // Maksimum 100 karakter olabilir.
            builder.Property(a => a.Title).IsRequired(true); // Boş olmamalı. 
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)"); // Nvarchar olarak oluş ve maksimum değer al. 
            builder.Property(a => a.Date).IsRequired(true);
            builder.Property(a => a.SeoAuthor).IsRequired(true);
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).IsRequired(true);
            builder.Property(a => a.SeoTags).IsRequired(true);
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewCount).IsRequired(true);
            builder.Property(a => a.CommentCount).IsRequired(true);
            builder.Property(a => a.Thumbnail).IsRequired(true);
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            builder.Property(a => a.CreatedByName).IsRequired(true);
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedByName).IsRequired(true);
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired(true);
            builder.Property(a => a.ModifiedDate).IsRequired(true);
            builder.Property(a => a.IsActive).IsRequired(true);
            builder.Property(a => a.IsDeleted).IsRequired(true);
            builder.Property(a => a.Note).HasMaxLength(500);

            // 1-N ilişkisini kurmamız gerek, her makalenin bir kategorisi kesinlikle olmalı ama bir kategori içerisinde birden fazla makale olabilir. 
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(a => a.CategoryID);
            // Aynı ilişkiyi User için de yapıyorum.
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(a => a.UserID);
            builder.ToTable("Articles");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
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

            builder.HasData(
                new Article
            {
                ID =1,
                CategoryID = 1, // C# kategorisine ait bir makale.
                Title = "C# 9.0 ve .NET 5 Yenilikleri",
                Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                Thumbnail = "default.jpg",
                SeoDescription = "C# 9.0 ve .NET 5 Yenilikleri",
                SeoTags= "C#, C# 9, .NET5, .NET Framework, .NET Core",
                SeoAuthor = "Kursad Kalender",
                Date = new DateTime(2025, 03, 17, 12, 00, 00),
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                ModifiedByName = "InitialCreate",
                ModifiedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                Note = "C# 9.0 ve .NET 5 Yenilikleri",
                UserID = 1,
                ViewCount = 2546,
                CommentCount = 1
            },
                new Article
            {
                ID =2,
                CategoryID = 2, // C++ kategorisine ait bir makale.
                Title = "C++ 11 ve 19 Yenilikleri",
                Content = "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                Thumbnail = "default.jpg",
                SeoDescription = "C++ 11 ve 19 Yenilikleri",
                SeoTags = "C++, C++ basics, C++ Tutorials, C++ OOP, C++ Data Structures",
                SeoAuthor = "Kursad Kalender",
                Date = new DateTime(2025, 03, 17, 12, 00, 00),
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                ModifiedByName = "InitialCreate",
                ModifiedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                Note = "C++ 11 ve 19 Yenilikleri",
                UserID = 1,
                ViewCount = 3521,
                CommentCount = 1
                },
                new Article
            {
                ID =3,
                CategoryID = 3, // JavaScript kategorisine ait bir makale.
                Title = "JavaScript ES2019 ve ES202 Yenilikleri",
                Content = "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır.",
                Thumbnail = "default.jpg",
                SeoDescription = "JavaScript ES2019 ve ES202 Yenilikleri",
                SeoTags ="JavaScript, JavaScript ES6 Features",
                SeoAuthor = "Kursad Kalender",
                Date = new DateTime(2025, 03, 17, 12, 00, 00),
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                ModifiedByName = "InitialCreate",
                ModifiedDate = new DateTime(2025, 03, 17, 12, 00, 00),
                Note = "JavaScript ES2019 ve ES202 Yenilikleri",
                UserID = 1,
                ViewCount = 1129,
                CommentCount = 1
                });
        }
    }
}

﻿using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public int ID { get; set; }

        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olamaz.")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MinLength(20, ErrorMessage = "{0} alanı {1} karakterden az olamaz.")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(250, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden az olamaz.")]
        public string Thumbnail { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(50, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden az olamaz.")]
        public string SeoAuthor { get; set; }

        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(150, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden az olamaz.")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Etiketler")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        [MaxLength(70, ErrorMessage = "{0} alanı {1} karakterden büyük olamaz.")]
        [MinLength(0, ErrorMessage = "{0} alanı {1} karakterden az olamaz.")]
        public string SeoTags { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        [DisplayName("Aktif mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public bool IsActive { get; set; }

        [DisplayName("Silinsin mi?")]
        [Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public bool IsDeleted { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryAddDto // Data Transfer Object, bir kategoriyi transfer etmek istiyoruz. Belli değerleri arka planda biz eklemek istiyoruz, tüm alanları dışarı açmaya gerek yok.
    {
        [DisplayName("Kategori Adı")] //Name adı olan değişkenlerin Kategori Adı olarak gözükmesini istiyoruz. 
        [Required(ErrorMessage = "{0} Boş Olamaz.")] // Boş geçilemez.
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden uzun olamaz.")]
        [MinLength(3, ErrorMessage ="{0} {1} karakterden kısa olamaz.")]
        public string Name { get; set; }

        [DisplayName("Kategori Açıklaması")] 
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden uzun olamaz.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olamaz.")]
        public string Description { get; set; }

        [DisplayName("Kategori Özel Not Alanı")]
        [MaxLength(500, ErrorMessage = "{0} {1} karakterden uzun olamaz.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olamaz.")]
        public string Note { get; set; }

        [DisplayName("Aktif mi?")] 
        [Required(ErrorMessage = "{0} Boş Olamaz.")] 
        public bool IsActive { get; set; }

    }
}

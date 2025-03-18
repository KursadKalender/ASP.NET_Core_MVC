using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class CategoryUpdateDto
    {
        [Required]
        public int ID { get; set; }

        [DisplayName("Kategori Adı")] 
        [Required(ErrorMessage = "{0} Boş Olamaz.")] 
        [MaxLength(70, ErrorMessage = "{0} {1} karakterden uzun olamaz.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden kısa olamaz.")]
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

        [DisplayName("Silindi mi?")]
        [Required(ErrorMessage = "{0} Boş Olamaz.")]
        public bool IsDeleted { get; set; }
    }
}

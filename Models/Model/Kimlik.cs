using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Kimlik")]
    public class Kimlik
    {
        [Key]
        public int KimlikId { get; set; }
        [DisplayName("Site Başlık")]
        [Required,StringLength(100,ErrorMessage ="100 Karekter olmalıdır")]
        public string Title { get; set; }
        [DisplayName("Anahtar Kelimeler")]
        [Required, StringLength(200, ErrorMessage = "200 Karekter olmalıdır")]
        public string Keywords { get; set; }
        [DisplayName("Site Açıklama")]
        [Required, StringLength(300, ErrorMessage = "300 Karekter olmalıdır")]
        public string Description { get; set; }
        [DisplayName("Site Logo")]
        public string LogoURL { get; set; }
        [DisplayName("Site Ünvan")]
        public string Unvan { get; set; }
    }
}
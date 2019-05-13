using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KurumsalWeb.Models.Model
{
    [Table("Kategori")]
    public class Kategori
    {
        [Key]
        public int KategoriId { get; set; }
        [Required,StringLength(50,ErrorMessage ="50 karekter olmalıdır")]
        public string KategoriAd { get; set; }
        public string Aciklama { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        
    }
}
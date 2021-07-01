using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wep_proje.Models
{
    [Table("urun")]
    public class urunler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int urun_id{ get; set; }
        [Required]
        public string urun_adi { get; set; }
        [Required]
        public int urun_fiyat { get; set; }
        [Required]
        public int urun_adedi { get; set; }
        [Required]
        public string urun_resmi { get; set; }
        [Required]
        public string urun_acıklama { get; set; }
      

        public virtual kategori Kategori { get; set; }
    }
}
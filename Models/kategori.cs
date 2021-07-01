using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace Wep_proje.Models
{
    [Table("kategori")]
    public class kategori
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int kategori_id { get; set; }
        [Required]
        public String kategori_adi { get; set; }
        public virtual List<urunler> Urunlers{ get; set; }
    }
}
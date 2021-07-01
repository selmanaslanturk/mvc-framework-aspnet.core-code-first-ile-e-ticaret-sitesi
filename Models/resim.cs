using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wep_proje.Models
{
    public class resim
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reim_id { get; set; }
        [Required]
        public string resimyolu { get; set; }
        [Required]
        public string baslik { get; set; }
    }
}
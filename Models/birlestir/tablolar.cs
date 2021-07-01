using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wep_proje.Models.birlestir
{
    public class tablolar
    {
        public List<urunler> urunlers { get; set; }
        public List<resim> resims { get; set; }
        public List<kategori> kategoris { get; set; }
    }
}
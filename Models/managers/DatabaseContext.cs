using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Wep_proje.Models.managers
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext():base("name=connextstring")
        {
              
        }
        public DbSet<kategori> kategoris { get; set; }
        public DbSet<urunler> urunler { get; set; }
        public DbSet<resim> Resims { get; set; }
        //public class VeritabanOlusturucu : CreateDatabaseIfNotExists<DbContext>
        //{
        //    //protected override void Seed(DbContext context)
        //    //{

        //    //    //kişi bilgisi
        //    //}

        //}

    }
}
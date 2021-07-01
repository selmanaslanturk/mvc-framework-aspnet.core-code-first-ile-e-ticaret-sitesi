using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Wep_proje.Models;
using Wep_proje.Models.birlestir;
using Wep_proje.Models.managers;

namespace Wep_proje.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
      
        public ActionResult Anasayfa()
        {
            DatabaseContext db = new DatabaseContext();
            tablolar tablo = new tablolar();
            //tablo.galeris = db.galeri.ToList();
            tablo.urunlers = db.urunler.ToList();
            tablo.resims = db.Resims.ToList();
            return View(tablo);
        }
        public ActionResult iletisim()
        { 
        
            return View();
        }
        public ActionResult urunler()
        {

            return View();
        }

        public ActionResult login()
        {

            return View();
        }

        public ActionResult sepet()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wep_proje.Models;
using Wep_proje.Models.managers;

namespace Wep_proje.Controllers
{
    public class urunlersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: urunlers
        public ActionResult Index()
        {
            var degerler = db.urunler.ToList();
            return View(degerler);
        }

        // GET: urunlers/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            urunler urunler = db.urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

    
        public ActionResult Create()
        {
            

            List<SelectListItem> degerler =
                (from i in db.kategoris.ToList()
                 select new SelectListItem()
                 {
                     Text = i.kategori_adi,
                     Value = i.kategori_id.ToString()
                 }).ToList();

            TempData["degerler"] = degerler;
            ViewBag.degerler = degerler;


           
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "urun_id,urun_adi,urun_fiyat,urun_adedi,urun_acıklama,Kategori")]urunler urunler)
        {
           

            urunler res = new urunler();
            var ktg = db.kategoris.Where(x => x.kategori_id == urunler.Kategori.kategori_id).FirstOrDefault();





            if (file != null && file.ContentLength > 0)

                try
                {

                    string path = Path.Combine(Server.MapPath("~/urunler"),
                                       Path.GetFileName(file.FileName));
                    file.SaveAs(path); string resim1 = file.FileName;
                    res.urun_resmi = ("urunler/" + resim1);
                    res.urun_adi = urunler.urun_adi;
                    res.urun_fiyat = urunler.urun_fiyat;
                    res.urun_adedi = urunler.urun_adedi;
                    res.Kategori=ktg;
                    res.urun_acıklama = urunler.urun_acıklama;
                     db.urunler.Add(res);
                    db.SaveChanges();
                    ViewBag.Message = "File uploaded successfully";

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }

            return View("Index");
        }
       

        // GET: urunlers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            urunler urunler = db.urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: urunlers/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "urun_id,urun_adi,urun_fiyat,urun_adedi,urun_resmi,urun_acıklama")] urunler urunler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urunler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urunler);
        }

        // GET: urunlers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            urunler urunler = db.urunler.Find(id);
            if (urunler == null)
            {
                return HttpNotFound();
            }
            return View(urunler);
        }

        // POST: urunlers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            urunler urunler = db.urunler.Find(id);
            db.urunler.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

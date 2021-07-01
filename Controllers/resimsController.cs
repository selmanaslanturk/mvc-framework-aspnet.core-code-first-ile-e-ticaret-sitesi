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
    public class resimsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: resims
        public ActionResult Index()
        {
            return View(db.Resims.ToList());
        }

        // GET: resims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resim resim = db.Resims.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        // GET: resims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: resims/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, [Bind(Include = "baslik")] resim resim)
        {

            if (file != null && file.ContentLength > 0)
                try
                {

                    string path = Path.Combine(Server.MapPath("~/ResimDosyasi"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    string resim1 = file.FileName;
                    resim res = new resim();
                    res.resimyolu = ("ResimDosyasi/" + resim1);
                    res.baslik = resim.baslik;
                    db.Resims.Add(res);
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
            ////return RedirectToAction("Index");
            return View();

        }

        // GET: resims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resim resim = db.Resims.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        // POST: resims/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "reim_id,resimyolu,baslik")] resim resim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resim);
        }

        // GET: resims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resim resim = db.Resims.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        // POST: resims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resim resim = db.Resims.Find(id);
            db.Resims.Remove(resim);
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

using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class HizmetController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();
        // GET: Hizmet
        public ActionResult Index()
        {
            return View(db.Hizmet.ToList());
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Hizmet hizmet,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string logoname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Hizmet/" + logoname);

                    hizmet.ResimURL = "/Uploads/Hizmet/" + logoname;
                }
                db.Hizmet.Add(hizmet);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(hizmet);
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                ViewBag.Uyari = "Güncellenecek Hizmet Bulunamadı";
            }
            var hizmet = db.Hizmet.Find(id);
            if (hizmet==null)
            {
                return HttpNotFound();
            }

            return View(hizmet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int? id,Hizmet hizmet,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                var h = db.Hizmet.Where(x => x.HizmetId == id).SingleOrDefault();
                if (ResimURL!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string hizmetname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Hizmet/" + hizmetname);

                    h.ResimURL = "/Uploads/Hizmet/" + hizmetname;
                }

                h.Baslik = hizmet.Baslik;
                h.Aciklama = hizmet.Aciklama;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var h = db.Hizmet.Find(id);
            if (h==null)
            {
                return HttpNotFound();
            }
            db.Hizmet.Remove(h);
            db.SaveChanges();
            return RedirectToAction("Index");
          
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStudentGrade.Models.EntityFramework;

namespace MvcStudentGrade.Controllers
{
    public class OgrencilerController : Controller
    {
        // GET: Ogrenciler

        DbMvcOkulEntities db = new DbMvcOkulEntities();

        public ActionResult OgrenciListele()
        {
            var ogr = db.TBLOGRENCILER.ToList();
            return View(ogr);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == p.TBLKULUPLER.KULUPID).FirstOrDefault();
            p.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p);
            db.SaveChanges();
            return RedirectToAction("OgrenciListele");
        }

        public ActionResult OgrenciSil(int id)
        {
            var ogr = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogr);
            db.SaveChanges();
            return RedirectToAction("OgrenciListele");
        }

        public ActionResult OgrenciGetir(int id)
        {
            var ogr = db.TBLOGRENCILER.Find(id);
            return View("OgrenciGetir", ogr);
        }

        public ActionResult OgrenciGuncelle(TBLOGRENCILER p)
        {
            var ogr = db.TBLOGRENCILER.Find(p.OGID);
            ogr.OGRADI = p.OGRADI;
            ogr.OGRCINSIYET = p.OGRCINSIYET;
            ogr.OGRFOTO = p.OGRFOTO;
            ogr.OGRSOYAD = p.OGRSOYAD;
            ogr.OGRKULUP = p.OGRKULUP;
            db.SaveChanges();
            return RedirectToAction("OgrenciListele");
        }
    }
}
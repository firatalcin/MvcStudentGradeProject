using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStudentGrade.Models.EntityFramework;

namespace MvcStudentGrade.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler

        DbMvcOkulEntities db = new DbMvcOkulEntities();

        public ActionResult KulupListele()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER p)
        {
            db.TBLKULUPLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("KulupListele");
        }

        public ActionResult KulupSil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("KulupListele");
        }

        public ActionResult KulupGetir(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            return View("KulupGetir", kulup);
        }

        public ActionResult KulupGuncelle(TBLKULUPLER p)
        {
            var klp = db.TBLKULUPLER.Find(p.KULUPID);
            klp.KULUPAD = p.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("KulupListele");

        }
    }
}
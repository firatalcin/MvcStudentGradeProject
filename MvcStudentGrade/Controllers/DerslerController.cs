using MvcStudentGrade.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStudentGrade.Controllers
{
    public class DerslerController : Controller
    {
        // GET: Dersler

        DbMvcOkulEntities db = new DbMvcOkulEntities();


        public ActionResult DersListele()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {
            db.TBLDERSLER.Add(p);
            db.SaveChanges();
            return RedirectToAction("DersListele");
        }

        public ActionResult DersSil(int id)
        {
            var drs = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(drs);
            db.SaveChanges();
            return RedirectToAction("DersListele");
        }

        public ActionResult DersGetir(int id)
        {
            var drs = db.TBLDERSLER.Find(id);
            return View("DersGetir", drs);
        }

        public ActionResult DersGuncelle(TBLDERSLER p)
        {
            var ders = db.TBLDERSLER.Find(p.DERSID);
            ders.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("DersListele");
        }
    }
}
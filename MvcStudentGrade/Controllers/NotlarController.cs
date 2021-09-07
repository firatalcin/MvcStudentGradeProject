using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStudentGrade.Models.EntityFramework;
using MvcStudentGrade.Models;

namespace MvcStudentGrade.Controllers
{
    public class NotlarController : Controller
    {
        // GET: Notlar

        DbMvcOkulEntities db = new DbMvcOkulEntities();

        public ActionResult NotListele()
        {
            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }

        [HttpGet]
        public ActionResult YeniNot()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniNot(TBLNOTLAR p)
        {
            db.TBLNOTLAR.Add(p);
            db.SaveChanges();
            return RedirectToAction("NotListele");
        }

        public ActionResult NotSil(int id)
        {
            var not = db.TBLNOTLAR.Find(id);
            db.TBLNOTLAR.Remove(not);
            db.SaveChanges();
            return RedirectToAction("NotListele");
        }

        public ActionResult NotGetir(int id)
        {
            var notlar = db.TBLNOTLAR.Find(id);
            return View("NotGetir", notlar);
        }

        [HttpPost]
        public ActionResult NotGetir(Class1 model, TBLNOTLAR p,int sinav1=0, int sinav2=0, int sinav3=0,int proje=0)
        {
            if(model.islem == "Hesapla")
            {
                int ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
                ViewBag.ort = ortalama;
            }
            if(model.islem == "NotGuncelle")
            {
                var snv = db.TBLNOTLAR.Find(p.NOTID);
                snv.SINAV1 = p.SINAV1;
                snv.SINAV2 = p.SINAV2;
                snv.SINAV3 = p.SINAV3;
                snv.PROJE = p.PROJE;
                snv.ORTALAMA = p.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("NotListele");
            }

            return View();
        }
    }
}
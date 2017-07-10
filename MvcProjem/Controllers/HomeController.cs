using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjem.Models;

namespace MvcProjem.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Kaydol()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add(string adi, string soyadi, string mail,string sifre , string kno)
        {
            VeriTabanı vt = new VeriTabanı();
            uye u = new uye();
            u.adi = adi;
            u.soyadi = soyadi;
            u.mail = mail;
            u.sifre = sifre;
            u.Tc = kno;
            vt.uyeler.Add(u);
            vt.SaveChanges();
            return RedirectToAction("Kaydol");
        }

    }
}

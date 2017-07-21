using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjem.Models;
using System.Net;
using System.Net.Mail;

namespace MvcProjem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kategori()
        {
            return View();
        }
        public ActionResult Ozellik()
        {
            return View();
        }
        public ActionResult Onay()
        {
            return View();
        }
        public ActionResult Admin_Kayit()
        {
            return View();
        }
        public ActionResult Giris()
        {
            Session["giris"] = "evet";
            return View();
        }
        public ActionResult Engelli()
        {
            return View();
        }
        public enum status
        {
            Onay,
            Pasif,
            Aktif,
            Blocked
        }
        VeriTabanı vt = new VeriTabanı();
        [HttpGet]
        public ActionResult Add(string txtkadi, string dtlParent, string kid)
        {
            if (kid == "0")
            {//kategori kaydet
                kategori k = new kategori();
                //k.id = int.Parse("1") ;
                k.kategoriadi = txtkadi;
                k.parentid = Convert.ToInt32(dtlParent);
                vt.kategoriler.Add(k);
                vt.SaveChanges();

            }
            else
            {//guncelle
                Int32 id = Convert.ToInt32(kid);
                kategori update = (from k in vt.kategoriler where k.id == id select k).FirstOrDefault();
                update.kategoriadi = txtkadi;
                update.parentid = Convert.ToInt32(dtlParent);
                vt.SaveChanges();
            }
            return RedirectToAction("Kategori");
        }
        public ActionResult Delete(int id)
        {
            kategori sil = (from k in vt.kategoriler where k.id == id select k).FirstOrDefault();
            vt.kategoriler.Remove(sil);
            vt.SaveChanges();
            return RedirectToAction("Kategori");
        }
        public ActionResult Bloke(int id)
        {
            Int32 uid = Convert.ToInt32(id);
            uye uptate = (from u in vt.uyeler where u.id == uid select u).FirstOrDefault();
            uptate.status = 3;
            vt.SaveChanges();
            return RedirectToAction("Onay");
        }
        //[HttpGet]
        //public ActionResult Admin_Add(string txtadi, string txtsoyadi, string txtmail, string txtsifre, string txtadres, string txttel, string txtTc)
        //{
        //    admin a = new admin();
        //    a.adi = txtadi;
        //    a.soyadi = txtsoyadi;
        //    a.mail = txtmail;
        //    a.sifre = txtsifre;
        //    a.adres = txtadres;
        //    a.tel = txttel;
        //    a.Tc = txtTc;
        //    vt.adminler.Add(a);
        //    vt.SaveChanges();
        //    return RedirectToAction("Admin_Kayit");
        //}
        public JsonResult Admin_Add(admin admin)
        {
            Result result = new Result();
            try
            {
                admin a = admin;
                admin.Add(a);
                result.success = true;
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Bir hata oluştu:" + ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public class Result
        {
            public bool success;
            public string message;
        }
        public JsonResult AddYetki(yetki yetki)
        {
            Result result = new Result();
            try
            {
                using (var vt = new MvcProjem.Models.VeriTabanı())
                {
                 var query = from a in vt.yetkiler where a.adminId == yetki.adminId select a;
                 var sil = query.FirstOrDefault();
                 if (sil != null)
                 {
                     vt.yetkiler.Remove(sil);
                     vt.SaveChanges();
                 }
                 yetki y = yetki;
                     yetki.Add(y);
                     result.success = true;
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = " Bir hata oluştu : " + ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GirisFnk(admin admin)
        {
            Session["Admin"] = admin.mail;
            Result result = new Result();
            using (var vt = new VeriTabanı())
            {
                var query = from a in vt.adminler where a.mail == admin.mail select a;
                var A = query.FirstOrDefault();
                if (A == null)
                {
                    result.success = false;
                    result.message = "Mail adresi sisteme kayıtlı değil !! ";
                }

                else if (A.sifre != admin.sifre)
                {
                    result.success = false;
                    result.message = "Hatalı şifre girdiniz !! ";
                }
                else
                {
                    result.success = true;
                    result.message = "Oturum açma işlemi başarı ile tamamlandı.";
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
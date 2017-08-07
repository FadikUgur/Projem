using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjem.Models;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;


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
            //Session["giris"] = "evet";
            return View();
        }
        public ActionResult Engelli()
        {
            return View();
        }
        public ActionResult Ilan_Ver(Int32 id)
        {
            if (id != 0)
            {
                ViewBag.Id = "" + id;
            }
            else
                ViewBag.Id = null;
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
            Result<Object> result = new Result<Object>();
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
        public class Result<K>
        {
            public bool success;
            public string message;
            public List<K> objectList;
        }
        public JsonResult AddYetki(yetki yetki)
        {
            Result<Object> result = new Result<Object>();
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
        public JsonResult GirisFnk(admin admin)
        {

            Result<Object> result = new Result<Object>();
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
                    Session["Admin"] = admin.mail;
                    result.success = true;
                    result.message = "Oturum açma işlemi başarı ile tamamlandı.";
                }

            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Ozellik_Add(int id, string name, string catIds)
        {
            Result<Object> result = new Result<Object>();
            try
            {
                using (var vt = new VeriTabanı())
                {
                    ozellik oz = new ozellik();
                    k_ozellik k_oz = new k_ozellik();
                    string[] cats = catIds.Split(',');
                    oz = new ozellik();
                    oz.name = name;
                    vt.ozellikler.Add(oz);
                    vt.SaveChanges();
                    for (int i = 0; i < cats.Length - 1; i++)
                    {
                        k_oz.kategoriid = Convert.ToInt32(cats[i]);
                        k_oz.ozellikid = oz.id;
                        vt.k_ozellik.Add(k_oz);
                        vt.SaveChanges();
                    }
                    result.success = true;
                }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Bir hata oluştu:" + ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Ozellik_List(int CatID)
        {
            Result<ozellik> result = new Result<ozellik>();
            List<ozellik> list = new List<ozellik>();
            using (var vt = new MvcProjem.Models.VeriTabanı())
            {
                var query = from o in vt.ozellikler join k in vt.k_ozellik on o.id equals k.ozellikid where k.kategoriid == CatID select o;

                foreach (var item in query)
                {
                    list.Add(item);
                }
                result.success = true;
                result.message = "";
                result.objectList = list;
                return Json(result, JsonRequestBehavior.AllowGet);

            }
        }
        public JsonResult Urun_Add(string urunadi, string aciklama, string tarih, int kategoriid, string degeri, string ozellikid, string value)
        {
            Result<urun> result = new Result<urun>();
            try
            {
               using (var vt =new VeriTabanı())
               {
                   urun u = new urun();
                   u.urunadi=urunadi;
                   u.aciklama=aciklama;
                   u.tarih=tarih;
                   u.kategoriid=kategoriid;
                   u.degeri=degeri;
                   vt.urunler.Add(u);
                   vt.SaveChanges();

                   string[] oIds = ozellikid.Split(',');
                   string[] vals = value.Split(',');
                   for (int i = 0; i < oIds.Length - 1; i++)
                   {
                       urunozellik uo = new urunozellik()
                       {
                           k_ozellikid = Convert.ToInt32(oIds[i]),
                           urunid = u.id,
                           value = vals[i]
                       };
                       vt.urunozellik.Add(uo);
                       vt.SaveChanges();
                   }

                   result.success = true;
                   result.message = "";
                   result.objectList = new List<urun>();
                   result.objectList.Add(u);
               }
            }
            catch (Exception ex)
            {
                result.success = false;
                result.message = "Bir hata oluştu:" + ex.Message;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult FileUpload(int id)
        {
            Result<Object> result = new Result<object>();
            string path = Server.MapPath("/Resimler/" + id + "/");
            Directory.CreateDirectory(path);
            var httpRequest = System.Web.HttpContext.Current.Request;
            HttpFileCollection uploadFiles = httpRequest.Files;

            if (httpRequest.Files.Count > 0)
            {
                int i;
                for (i = 0; i < uploadFiles.Count; i++)
                {
                    HttpPostedFile postedFile = uploadFiles[i];
                    var filePath = path + postedFile.FileName;
                    postedFile.SaveAs(filePath);

                    string yol = "../.." + "/Resimler/" + id + "/" + postedFile.FileName;
                    resimler resim = new resimler();
                    resim.id = id;
                    resim.src = yol;
                    resim.urunid = id;
                    vt.resimler.Add(resim);
                    vt.SaveChanges();

                }
               
            }


          

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
    }
}
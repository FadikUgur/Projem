using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjem.Models;

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
        public ActionResult Uye_Onay()
        {
            return View();
        }
        
        
        [HttpGet]
        public ActionResult Add(string txtkadi, string dtlParent, string kid)
        {
            VeriTabanı vt = new VeriTabanı();
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
                kategori update = (from k in vt.kategoriler where k.id ==id select k).FirstOrDefault();
                update.kategoriadi = txtkadi;
                update.parentid = Convert.ToInt32(dtlParent);
                vt.SaveChanges();
            }
            return RedirectToAction("Kategori"); 
        }
        public ActionResult Delete(int id)
        {
            VeriTabanı vt = new VeriTabanı();

            kategori sil = (from k in vt.kategoriler where k.id == id select k).FirstOrDefault();
            vt.kategoriler.Remove(sil);
            vt.SaveChanges();
            return RedirectToAction("Kategori");
        }

       
    }
}


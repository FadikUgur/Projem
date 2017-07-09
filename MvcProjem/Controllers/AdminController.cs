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
        public ActionResult Yetki()
        {
            return View();
        }
        
        
        [HttpGet]
        public void Add(string txtkadi)
        {
            VeriTabanı vt = new VeriTabanı();
            if (txtkadi == null)
            {
                //mesajj ver
            }
            else
            {
                kategori k = new kategori();
                //k.id = int.Parse("1") ;
                k.kategoriadi = txtkadi;
                vt.kategoriler.Add(k);
                vt.SaveChanges();
                
            }
        }
        [HttpGet]
        public void Delete(string txtkadi)
        {
            VeriTabanı vt = new VeriTabanı();
            if (txtkadi == null)
            {
                //mesajj ver
            }
            else
            {
                kategori k = new kategori();
                var sil = vt.kategoriler.Where(sl => sl.kategoriadi == txtkadi).First();
                vt.kategoriler.Remove(sil);
                vt.SaveChanges();

            }
        }

        //[HttpGet]
        //public string list(string kadi)
        //{
        //    VeriTabanı vt = new VeriTabanı();
        //    kategori k = new kategori();
        //    var liste = from f in vt.kategoriler
        //                select new { k.kategoriadi };
        //    return liste.ToString();
        //}
    }
}


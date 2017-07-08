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
            


            //VeriTabanı vt = new VeriTabanı();
            ////string id = txtkdi;
            //string adi = txtkadi;
            //kategori k = new kategori();
            //k.kategoriadi = adi;
            //vt.kategoriler.Add(k);
            //vt.SaveChanges();
            
       //Makale yeni_makale = new Makale(); //Tablo örneğini aldık.
       //yeni_makale.baslik = "Hello World"; //TAblo alanlarını dolduruyoruz.
       //yeni_makale.icerik = "Lorem ipsum";
       //db.Makale.Add(yeni_makale); Oluşturduğumuz model örneğinin Add Methodu ile yeni_makale isimli örneği Makale tablosuna ekliyoruz.
       //db.SaveChanges(); //Yine modelin. SaveChanges() ( DeğişiklikleriKaydet ) Methodu ile değişiklikleri kaydediyoruz.
        }
    }
}

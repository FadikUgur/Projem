using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public void Add(string txtKategoriAdi)
        {
           
        }
    }
}

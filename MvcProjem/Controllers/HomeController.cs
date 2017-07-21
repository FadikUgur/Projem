using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcProjem.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;

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
        public ActionResult U_Onay()
        {
            var id = Convert.ToInt32(Request["id"]);
            using (var vt = new VeriTabanı())
            {
                var query = from a in vt.uyeler where a.id == id select a;
                var u = query.FirstOrDefault();
                u.status =(int) uye.statusState.Aktif;
                vt.SaveChanges();
                
            }
            return RedirectToAction("Login", "Home");
        }
        

        [HttpGet]
        public ActionResult Add(string adi, string soyadi, string mail,string sifre , string kno)
        {
            VeriTabanı vt = new VeriTabanı();
            uye u = new uye();
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/mail.xml"));
            string ActivationUrl;
            try
            {
                u.adi = adi;
                u.soyadi = soyadi;
                u.mail = mail;
                u.sifre = sifre;
                u.Tc = kno;
                u.status =(int) uye.statusState.Pasif;
                vt.uyeler.Add(u);
                vt.SaveChanges();

                string m_adres, m_sifre;
                foreach (DataRow dr in ds.Tables["mail"].Rows)
                {
                    m_adres = dr["mailadres"].ToString();
                    m_sifre = dr["mailsifre"].ToString();

                    MailMessage mesajım = new MailMessage();
                    mesajım.From = new MailAddress(mail);
                    mesajım.To.Add(mail);
                    mesajım.Subject = "Doğrulma Email";
                    ActivationUrl = Server.HtmlEncode("http://localhost:4684/Home/U_Onay?id=" + GetUserID(mail));
                    mesajım.Body = "<a href='" + ActivationUrl + "'>Üyeliğinizi Doğrulamak İçin Tıklayın..</a>";
                    mesajım.IsBodyHtml = true;
                    SmtpClient istemci = new SmtpClient();
                    istemci.Host = "smtp.gmail.com";
                    istemci.Port = 587;
                    istemci.Credentials = new NetworkCredential(m_adres, m_sifre);
                    istemci.EnableSsl = true;
                    istemci.Send(mesajım);
                }
            }
            catch(Exception ex)
            {
            }
            return RedirectToAction("Kaydol");
        }

        private int GetUserID(string mail)
        {
            using (var vt = new VeriTabanı())
            {
                var query = from a in vt.uyeler where a.mail==mail select a;
                var u = query.FirstOrDefault();
                return u.id;
            }

        }
        public class Result
        {
            public bool success = false;
            public string message = "";
        }
        [HttpGet]
        public JsonResult Control(uye uye)
        {
            Result result = new Result();
            using (var vt = new VeriTabanı())
            {
                var query = from a in vt.uyeler where a.mail == uye.mail select a;
                var u = query.FirstOrDefault();
                if (u==null)
                {
                    result.success = false;
                    result.message = "Mail adresi sisteme kayıtlı değil !! ";
                }

                else if (u.sifre != uye.sifre)
                {
                    result.success = false;
                    result.message = "Hatalı şifre girdiniz !! ";
                }
                else if (u.status != 2)
                {
                    result.success = false;
                    if (u.status == 1)
                        result.message = "Hesabını mail adresine gelen linkten onaylayın !! ";
                    else
                        result.message = "Hasabınız bloke edilmiştir sistem yönteicisine başvurunuz !! ";
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

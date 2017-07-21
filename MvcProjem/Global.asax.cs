using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcProjem.Models;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using MvcProjem.Migrations;

namespace MvcProjem
{

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        public void Application_Start()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<VeriTabanı, MvcProjem.Models.VeriTabanı.Configuration>("MvcProjemConnectionString"));
            using (var vt = new VeriTabanı())
            {
                if (vt.Database.Exists())
                {
                    DbMigrator migrator = new System.Data.Entity.Migrations.DbMigrator(new Configuration());
                    migrator.Update();
                }
                else
                {
                    vt.Database.Create();
                }
            }
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

        }
        protected void Session_Start(Object sender, EventArgs e)
        {


        }

        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            //Session["giris"]="";
            if (url.IndexOf("Admin") !=-1)
            {
                if (url == "http://localhost:4684/Admin/Giris")
                    return;
                else if (Session["Admin"] != null)
                {
                    using (var vt = new VeriTabanı())
                    {
                        string session = Session["Admin"].ToString();
                        var query = from a in vt.adminler
                                    join c in vt.yetkiler on a.id equals c.adminId
                                    where a.mail == session
                                    select c;

                        MvcProjem.Controllers.Yetkiler.editAdmin = query.FirstOrDefault().editAdmin;
                        MvcProjem.Controllers.Yetkiler.memberBlocked = query.FirstOrDefault().memberBlocked;
                        MvcProjem.Controllers.Yetkiler.memberProcess = query.FirstOrDefault().memberProcess;


                    }
                    if (url.EndsWith("/Onay"))
                    {
                        if (MvcProjem.Controllers.Yetkiler.memberProcess)
                            return;
                        else
                            Response.Redirect("http://localhost:4684/Admin/Engelli");
                    }

                }
            }
        }
    }
}
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
    }
}
using System;
using System.Data.Entity.Migrations;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MvcProjem.Models
{
    public partial class VeriTabanı:DbContext
    {
        public VeriTabanı()
            : base("name=MvcProjemConnectionString")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<VeriTabanı, MvcProjem.Models.VeriTabanı.Configuration>("MvcProjemConnectionString"));
        }
       
        public virtual DbSet<admin> adminler { get; set; }
        public virtual DbSet<iletisim> iletisimler { get; set; }
        public virtual DbSet<kategori> kategoriler { get; set; }
        public virtual DbSet<ozellik> ozellikler { get; set; }
        public virtual DbSet<resimler> resimler { get; set; }
        public virtual DbSet<urun> urunler { get; set; }
        public virtual DbSet<urunozellik> urunozellik { get; set; }
        public virtual DbSet<yetki> yetkiler { get; set; }
        public virtual DbSet<uye> uyeler { get; set; }
        public virtual DbSet<yorumlar> yorumlar { get; set; }

    }
  
}
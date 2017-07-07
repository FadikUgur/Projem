using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjem
{
    public class admin
    {
        public int id { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string mail { get; set; }
        public string sifre { get; set; }
        public string adres { get; set; }
        public string tel { get; set; }
        public string Tc { get; set; }

        //public virtual yetki yetki { get; set; }
    }
}
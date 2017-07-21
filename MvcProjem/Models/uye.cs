using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjem
{
    public class uye
    {
        public enum statusState { Pasif = 1, Aktif= 2 , Engelli =3}

        public uye()
        {
            this.iletisimler = new HashSet<iletisim>();
        }
        public int id { get; set; }
        public string adi { get; set; }
        public string soyadi { get; set; }
        public string mail { get; set; }
        public string sifre { get; set; }
        public string Tc { get; set; }
        public int status { get; set; }
        public virtual ICollection<iletisim> iletisimler { get; set; }
       

    }
}
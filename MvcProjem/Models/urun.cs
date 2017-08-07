using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjem
{
    public class urun
    {
        public int id { get; set; }
        public string urunadi { get; set; }
        public string aciklama { get; set; }
        public string tarih { get; set; }
        public string degeri { get; set; }
        public Nullable<int> kategoriid { get; set; }

    }
}
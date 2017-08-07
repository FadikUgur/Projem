using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjem
{
    public class iletisim
    {
        public int id { get; set; }
        public Nullable<int> uyeid { get; set; }
        public string adres { get; set; }
        public string tel { get; set; }
        public string ulke { get; set; }
        public string sehir { get; set; }
        public string ilce { get; set; }
    }
}
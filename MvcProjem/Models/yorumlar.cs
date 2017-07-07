using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjem
{
    public class yorumlar
    {
        public int id { get; set; }
        public string yorum { get; set; }
        public string tarih { get; set; }
        public Nullable<int> urunid { get; set; }
    }
}
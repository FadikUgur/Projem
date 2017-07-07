using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjem
{
    public class yetki
    {
        public int id  { get; set; }
        public string yetkituru { get; set; }
        //public Nullable<int> id { get; set; }

        //public virtual admin admin { get; set; }
    }
}
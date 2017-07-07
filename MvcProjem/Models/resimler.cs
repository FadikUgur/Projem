using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjem
{
    public class resimler
    {
        public int id { get; set; }
        public string src { get; set; }
        public Nullable<int> urnid { get; set; }

        public virtual iletisim iletisimler { get; set; }
    }
}
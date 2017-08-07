using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjem
{
    public class urunozellik
    {
        public int id { get; set; }
        public int k_ozellikid { get; set; }
        public string value { get; set; }
        public int urunid { get; set; }
    }
}
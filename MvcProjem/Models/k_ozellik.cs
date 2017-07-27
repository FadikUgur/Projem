using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjem.Models
{
    public class k_ozellik
    {
        public int id { get; set; }
        public int kategoriid { get; set; }
        public int ozellikid { get; set; }
    }
}
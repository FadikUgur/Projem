using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace MvcProjem
{
    public class kategori
    {
        public int id { get; set; }
        public string kategoriadi { get; set; }
        public int? parentid { get; set; }
    }
}
using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjem
{
    public class kategori
    {
        public kategori()
        {
            this.urunler = new HashSet<urun>();
            this.ozellik = new HashSet<ozellik>();
        }
        public int id { get; set; }
        public string kategoriadi { get; set; }
        public int? parentid { get; set; }
        public virtual ICollection<urun> urunler { get; set; }
        public virtual ICollection<ozellik> ozellik { get; set; }
    }
}
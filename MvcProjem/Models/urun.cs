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
        public urun()
        {
            this.resimler = new HashSet<resimler>();
            this.yorumlar = new HashSet<yorumlar>();
        }
        public int id { get; set; }
        public string urunadi { get; set; }
        public string aciklama { get; set; }
        public string tarih { get; set; }
        public Nullable<int> kategoriid { get; set; }

        public virtual kategori kategori { get; set; }
        public virtual urunozellik urunozellik { get; set; }
        public virtual ICollection<resimler> resimler { get; set; }
        public virtual ICollection<yorumlar> yorumlar { get; set; }
    }
}
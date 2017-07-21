using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcProjem.Controllers;
namespace MvcProjem.Models
{
    public class yetki
    {
        public int id { get; set; }
        public int adminId { get; set; }
        public bool memberProcess { get; set; }
        public bool memberBlocked { get; set; }
        public bool editAdmin { get; set; }


        public void Add(yetki y)
        {
            using (var vt = new VeriTabanı())
            {
                vt.yetkiler.Add(y);
                vt.SaveChanges();
            }
        }
        public void GetAdminYetki(int Id)
        {
            using (var vt = new VeriTabanı())
            {
                var query = from a in vt.yetkiler where a.adminId == Id select a;
                var y = query.FirstOrDefault();
                if (y != null)
                {
                    Yetkiler.memberBlocked = y.memberBlocked;
                    Yetkiler.memberProcess = y.memberProcess;
                    Yetkiler.editAdmin = y.editAdmin;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bán_Mỹ_Phẩm.Models;

namespace Bán_Mỹ_Phẩm.Areas.Admin.Controllers
{
    public class ThuongHieuAPIController : ApiController
    {

        [HttpGet]
        public List<Thuonghieu> GetTHLists()
        {
            QLmyphamEntities db = new QLmyphamEntities();
            return db.Thuonghieux.ToList();
        }

        [HttpGet]
        public Thuonghieu GetTH(int id)
        {
            QLmyphamEntities db = new QLmyphamEntities();
            return db.Thuonghieux.FirstOrDefault(s => s.Math == id);
        }

        [HttpPost]
        public int InsertNewTH([FromBody] Thuonghieu TH)
        {
            try
            {
                QLmyphamEntities db = new QLmyphamEntities();
                Thuonghieu s = new Thuonghieu();
                s.Math = TH.Math;
                s.Tenth = TH.Tenth;               
                db.Thuonghieux.Add(s);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        [HttpPost]
        public bool UpdateTH([FromBody] Thuonghieu TH)
        {
            try
            {
                QLmyphamEntities db = new QLmyphamEntities();
                Thuonghieu th = db.Thuonghieux.FirstOrDefault(s => s.Math == TH.Math);
                if (th == null)
                    return false;
                th.Math = TH.Math;
                th.Tenth = TH.Tenth;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        public bool DeleteTH([FromBody] Thuonghieu TH)
        {
            QLmyphamEntities db = new QLmyphamEntities();
            Thuonghieu th = db.Thuonghieux.FirstOrDefault(s => s.Math == TH.Math);
            if (th == null)
                return false;
            db.Thuonghieux.Remove(th);
            db.SaveChanges();
            return true;
        }
    }
}

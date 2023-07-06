using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bán_Mỹ_Phẩm.Models;

namespace Bán_Mỹ_Phẩm.Controllers
{
    public class SanphamController : Controller
    {
        //
        // GET: /Sanpham/

        QLmyphamEntities db = new QLmyphamEntities();

        // GET: Sanpham
        public ActionResult MAC()
        {
            var nh = db.Sanphams.Where(n=>n.Math==2).Take(4).ToList();
           return PartialView(nh);
        }

        public ActionResult Dior()
        {
            var td = db.Sanphams.Where(n => n.Math == 4).Take(4).ToList();
            return PartialView(td);
        }

        public ActionResult xemchitiet(int Masp=0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n=>n.Masp==Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }

    }
}

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

        QL_MyPham_DAEntities3 db = new QL_MyPham_DAEntities3();

        // GET: Sanpham
        public ActionResult Dior()
        {
            var nh = db.SanPhams.Where(n=>n.MaTH=="TH00").Take(4).ToList();
           return PartialView(nh);
        }

        public ActionResult Burberry()
        {
            var td = db.SanPhams.Where(n => n.MaTH == "TH05").Take(4).ToList();
            return PartialView(td);
        }

        public ActionResult xemchitiet(string Masp="")
        {
            var chitiet = db.SanPhams.SingleOrDefault(n=>n.MaSP==Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }

    }
}

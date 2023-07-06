using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bán_Mỹ_Phẩm.Models;
using System.Net;

namespace Bán_Mỹ_Phẩm.Controllers
{
    public class ThuongHieuController : Controller
    {
        //
        // GET: /ThuongHieuPartial/
        QLmyphamEntities db = new QLmyphamEntities();

        public ActionResult ThuongHieuPartial()
        {
            var ListTH = db.Thuonghieux.OrderBy(th => th.Tenth).ToList();
            return PartialView(ListTH);
        }


        public ViewResult SanPhamTheoTH(int maTH)
        {
            var ListTH = db.Sanphams.Where(s => s.Math == maTH).OrderBy(s => s.Giatien).ToList();
            if (ListTH.Count == 0)
            {
                ViewBag.Imagename = "/Images/erro.png";            
                ViewBag.SanPham = "Không có sản phẩm nào thuộc thương hiệu này";
            }
            return View(ListTH);
        }

        public ActionResult xemchitiet(int Masp = 0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n => n.Masp == Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }     

    }
}

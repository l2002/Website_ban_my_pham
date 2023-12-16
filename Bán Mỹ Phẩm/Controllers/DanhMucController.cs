using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bán_Mỹ_Phẩm.Models;
using System.Net;

namespace Bán_Mỹ_Phẩm.Controllers
{
    public class DanhMucController : Controller
    {
        //
        // GET: /ThuongHieuPartial/
        QL_MyPham_DAEntities3 db = new QL_MyPham_DAEntities3();

        public ActionResult ThuongHieuPartial()
        {
            var ListTH = db.ThuongHieux.OrderBy(th => th.TenTH).ToList();
            return PartialView(ListTH);
        }


        public ViewResult SanPhamTheoTH(string maTH)
        {
            var ListTH = db.SanPhams.Where(s => s.MaTH == maTH).OrderBy(s => s.GiaBan).ToList();
            if (ListTH.Count == 0)
            {
                ViewBag.Imagename = "/Images/erro.png";            
                ViewBag.SanPham = "Không có sản phẩm nào thuộc thương hiệu này";
            }
            return View(ListTH);
        }

        public ActionResult xemchitiet(string Masp = "")
        {
            var chitiet = db.SanPhams.SingleOrDefault(n => n.MaSP == Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }     

    }
}

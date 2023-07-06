using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bán_Mỹ_Phẩm.Models;
using PagedList;

namespace Bán_Mỹ_Phẩm.Areas.Admin.Controllers
{
    public class SanphamController : Controller
    {
        //
        // GET: /Admin/Sanpham/

        QLmyphamEntities db = new QLmyphamEntities();

        public ActionResult DanhSach(int ?page)
        {
            if (page == null) page = 1;
            var sp = db.Sanphams.OrderBy(x => x.Masp);           
            int pageSize = 10;       
            int pageNumber = (page ?? 1);
            return View(sp.ToPagedList(pageNumber, pageSize));

        }

                
        public ActionResult Create()
        {

            var hangselected = new SelectList(db.Hangsanxuats, "Mahang", "Tenhang");
            ViewBag.Mahang = hangselected;
            var hdhselected = new SelectList(db.Thuonghieux, "Math", "Tenth");
            ViewBag.Math = hdhselected;
            return View();
        }

        // Tạo sản phẩm mới phương thức POST: Admin/Home/Create
        [HttpPost]
        public ActionResult Create(Sanpham sanpham)
        {
            try
            {
                //Thêm  sản phẩm mới
                db.Sanphams.Add(sanpham);
                // Lưu lại
                db.SaveChanges();
                // Thành công chuyển đến trang Danhsach
                return RedirectToAction("Danhsach");
            }
            catch
            {
                return View();
            }
        }

        // Sửa sản phẩm GET lấy ra ID sản phẩm: Admin/Home/Edit/5
        public ActionResult Edit(int id)
        {
            // Hiển thị dropdownlist
            var sp = db.Sanphams.Find(id);
            var hangselected = new SelectList(db.Hangsanxuats, "Mahang", "Tenhang", sp.Mahang);
            ViewBag.Mahang = hangselected;
            var thselected = new SelectList(db.Thuonghieux, "Math", "Tenth", sp.Math);
            ViewBag.Math = thselected;
            return View(sp);

        }

        // POST: Admin/Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Sanpham sanpham)
        {
            try
            {
                // Sửa sản phẩm theo mã sản phẩm
                var oldItem = db.Sanphams.Find(sanpham.Masp);
                oldItem.Tensp = sanpham.Tensp;
                oldItem.Giatien = sanpham.Giatien;
                oldItem.Soluong = sanpham.Soluong;
                oldItem.Mota = sanpham.Mota;
                oldItem.Anhbia = sanpham.Anhbia;
                oldItem.Mahang = sanpham.Mahang;
                oldItem.Math = sanpham.Math;
                // lưu lại
                db.SaveChanges();
                // xong chuyển qua Danhsach
                return RedirectToAction("Danhsach");
            }
            catch
            {
                return View();
            }
        }

        // Xoá sản phẩm phương thức GET: Admin/Home/Delete/5
        public ActionResult Delete(int id)
        {
            var sp = db.Sanphams.Find(id);
            return View(sp);
        }

        // Xoá sản phẩm phương thức POST: Admin/Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
           
            try
            {
                //Lấy được thông tin sản phẩm theo ID(mã sản phẩm)
                var dt = db.Sanphams.Find(id);
                // Xoá
                db.Sanphams.Remove(dt);
                // Lưu lại
                db.SaveChanges();
                TempData["Message"] = "You are not authorized.";
                return RedirectToAction("Danhsach");
                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            var sp = db.Sanphams.Find(id);
            return View(sp);
        }

    }
}

using Bán_Mỹ_Phẩm.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace Bán_Mỹ_Phẩm.Areas.Admin.Controllers
{
    public class HangSanXuatController : Controller
    {
        //
        // GET: /Admin/HangSanXuat/

        QLmyphamEntities db = new QLmyphamEntities();

        public ActionResult DanhSach(int ?page)
        {
            if (page == null) page = 1;
            var hsx = db.Hangsanxuats.OrderBy(x => x.Mahang);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(hsx.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahang,Tenhang")] Hangsanxuat hsx)
        {
            if (ModelState.IsValid)
            {
                db.Hangsanxuats.Add(hsx);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }

            return View(hsx);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hangsanxuat hsx = db.Hangsanxuats.Find(id);
            if (hsx == null)
            {
                return HttpNotFound();
            }
            return View(hsx);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hangsanxuat hsx = db.Hangsanxuats.Find(id);
            if (hsx == null)
            {
                return HttpNotFound();
            }
            return View(hsx);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahang,Tenhang")] Hangsanxuat hsx)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hsx).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View(hsx);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hangsanxuat hsx = db.Hangsanxuats.Find(id);
            if (hsx == null)
            {
                return HttpNotFound();
            }
            return View(hsx);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hangsanxuat hsx = db.Hangsanxuats.Find(id);
            db.Hangsanxuats.Remove(hsx);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}

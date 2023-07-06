using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bán_Mỹ_Phẩm.Models;
using PagedList;
using System.Net;
using System.Data;

namespace Bán_Mỹ_Phẩm.Areas.Admin.Controllers
{
    public class ThuonghieuController : Controller
    {
        //
        // GET: /Admin/Thuonghieu/

        QLmyphamEntities db=new QLmyphamEntities();

        public ActionResult DanhSach(int? page)
        {
            if (page == null) page = 1;
            var th = db.Thuonghieux.OrderBy(x => x.Math);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(th.ToPagedList(pageNumber, pageSize));

        }

               
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Math,Tenth")] Thuonghieu th)
        {
            if (ModelState.IsValid)
            {
                db.Thuonghieux.Add(th);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }

            return View(th);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuonghieu th = db.Thuonghieux.Find(id);
            if (th == null)
            {
                return HttpNotFound();
            }
            return View(th);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuonghieu th = db.Thuonghieux.Find(id);
            if (th == null)
            {
                return HttpNotFound();
            }
            return View(th);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Math,Tenth")] Thuonghieu th)
        {
            if (ModelState.IsValid)
            {
                db.Entry(th).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View(th);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Thuonghieu th = db.Thuonghieux.Find(id);
            if (th == null)
            {
                return HttpNotFound();
            }
            return View(th);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Thuonghieu th = db.Thuonghieux.Find(id);
            db.Thuonghieux.Remove(th);
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

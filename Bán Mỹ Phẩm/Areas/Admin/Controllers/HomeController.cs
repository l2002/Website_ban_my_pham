using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bán_Mỹ_Phẩm.Models;
using PagedList;

namespace Bán_Mỹ_Phẩm.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/
        QLmyphamEntities db = new QLmyphamEntities();

        public ActionResult Index()
        {
            return View();
        }
       

    }
}

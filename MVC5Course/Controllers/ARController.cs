using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MVC5Course.Models;
using Microsoft.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return PartialView("Index");
        }

        public ActionResult FileTest()
        {
            return File(
                Server.MapPath("~/Content/nba.png"),
                "image/png",
                "test.png");
        }

        public ActionResult JsonTest()
        {
            var db = new FabricsEntities();
            db.Configuration.LazyLoadingEnabled = false;
            var data = db.Product.Take(3);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult RedirectTest()
        {
            return RedirectToAction("Edit", "");
        }
    }
}
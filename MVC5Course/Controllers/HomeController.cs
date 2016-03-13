using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {

        // TODO: Net yet ready
        [共用的ViewBag資料共享於部分HomeController動作方法]
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [共用的ViewBag資料共享於部分HomeController動作方法]
        [紀錄Action的執行時間]
        public ActionResult Test()
        {
            return View();
        }
        [HandleError(ExceptionType = typeof(ArgumentException), View = "ErrorArgument")]
        public ActionResult ErrorTest(string errorType)
        {
            if (errorType =="1")
            {
                throw new Exception("Error 1");

            }
            if (errorType == "2")
            {
                throw new ArgumentException("Error 1");

            }


            return Content("No Error");
        }

        public ActionResult RazorTest()
        {

            int[] data = new int[] { 1, 2, 3, 4, 5 };
            return PartialView(data);
        }
    }
}
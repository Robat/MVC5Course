using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

    // Code Snippet Shortcut: mvcaction4
         public ActionResult MemberProfile()
        {
            return View();
        }

        // Code Snippet Shortcut: mvcpostaction4
        [HttpPost]
        public ActionResult MemberProfile(MemberViewModel data)
        {
            return View();
        }

    }


}
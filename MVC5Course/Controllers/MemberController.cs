using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
        [Authorize]
        public class MemberController : Controller, IMemberController
        {
            [AllowAnonymous]
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [AllowAnonymous]
            public ActionResult Login(LoginViewModel login)
            {
                if (CheckLogin(login.Email, login.Password))
                {
                    FormsAuthentication.RedirectFromLoginPage(login.Email, false);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("Password", "您輸入的帳號或密碼錯誤");

                return View();
            }

            private bool CheckLogin(string username, string password)
            {
                return (
                    username == "viewmuse@gmail.com" &&
                    password == "123"
                    );
            }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }

}
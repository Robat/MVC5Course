using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public interface IMemberController
    {
        ActionResult Login();
        ActionResult Login(LoginViewModel login);
    }
}
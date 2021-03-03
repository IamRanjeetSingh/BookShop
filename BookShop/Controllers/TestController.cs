using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    [AllowAnonymous]
    public class TestController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Content("You have logged in");
        }

        [HttpGet]
        public ActionResult Login()
		{
            return View();
		}

        [HttpPost]
        public ActionResult Login(string email)
		{
            if (email != "abc")
			{
                ViewData.ModelState.AddModelError("LoginError", "Invalid Email");
                ViewBag.IsStateInvalid = true;
                return View("Login");
			}
            ViewBag.IsStateInvalid = false;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Form()
		{
            return PartialView("_Form");
		}
    }
}
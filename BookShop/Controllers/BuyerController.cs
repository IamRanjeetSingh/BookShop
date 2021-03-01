using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class BuyerController : Controller
    {
        // GET: Buyer
        public ActionResult Index()
        {
            
            ViewBag.Name = HttpContext.User.Identity.Name;
            ViewBag.Type = HttpContext.User.Identity.AuthenticationType;
            ViewBag.IsAuthenticated = HttpContext.User.Identity.IsAuthenticated;

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrozenCritters.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //HttpCookie cart = new HttpCookie("cart");
            //Response.Cookies.Add(cart);
            return View();
        }
    }
}
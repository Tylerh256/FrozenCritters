using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrozenCritters.Controllers
{
    public class LawsController : Controller
    {
        // GET: Laws
        public ActionResult Index()
        {
            return View();
        }
    }
}
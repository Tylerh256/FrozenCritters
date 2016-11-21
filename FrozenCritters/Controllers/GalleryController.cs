using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrozenCritters.Controllers
{
    [RequireHttps]
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Gallery()
        {
            return View();
        }
    }
}
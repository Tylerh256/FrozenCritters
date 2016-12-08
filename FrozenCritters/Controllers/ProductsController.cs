using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrozenCritters.Models;
using System.Web.SessionState;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace FrozenCritters.Controllers
{
    [RequireHttps]
    public class ProductsController : Controller
    {
        [HttpGet]
        public ActionResult Products(int id)
        {
            List<Products> prods = FrozenCrittersDb.GetProductsPage(id);
            return View(prods);
        }

        public ActionResult IndividualProductsPage(int id)
        {

            Products prod = FrozenCritters.Models.FrozenCrittersDb.GetProd(id);
            return View(prod);
        }

        public ActionResult PostAddToCartPage(int id)
        {
            ViewModel.CheckoutProductViewModel prod = Models.FrozenCrittersDb.getCheckoutProd(id);
            return View(prod);
        }

        public ActionResult ShoppingCart()
        {
            return View();
        }

    }
}
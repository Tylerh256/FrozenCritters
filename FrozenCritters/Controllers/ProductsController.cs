using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrozenCritters.Models;
using System.Web.SessionState;

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
            Products prod = Models.FrozenCrittersDb.GetProd(id);
            //Request.Cookies["cart"].Values[prod.ProductsName] = prod.ProductsId.ToString();
            Session.Add(prod.ProductsName, prod.ProductsId);
            return View(prod);
        }

        public ActionResult ShoppingCart()
        {
            return View();
        }

    }
}
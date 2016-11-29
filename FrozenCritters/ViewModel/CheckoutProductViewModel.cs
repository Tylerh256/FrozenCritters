using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrozenCritters.ViewModel
{
    public class CheckoutProductViewModel
    {
        public int ProductsId { get; set; }

        public string ProductsName { get; set; }

        public int ProductsQuantity { get; set; }
    }
}
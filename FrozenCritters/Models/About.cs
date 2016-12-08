using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrozenCritters.Models
{
    public class About
    {
        [Display(Name = "About Description: ")]
        public string AboutDescription { get; set; }
    }
}
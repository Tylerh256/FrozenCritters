using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrozenCritters.Models
{
    public class Contact
    {
        [Display(Name = "Email: ")]
        public string ContactEmail { get; set; }

        [Display(Name = "Phone Number: ")]
        public string ContactPhoneNumber { get; set; }

        [Display(Name = "Hours of Business: ")]
        public string ContactHours { get; set; }
    }
}
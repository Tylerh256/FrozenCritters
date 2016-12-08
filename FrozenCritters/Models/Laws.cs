using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrozenCritters.Models
{
    public class Laws
    {
        public int LawsId { get; set; }

        [Display(Name = "Law Title: ")]
        public string LawsTitle { get; set; }
        
        [Display(Name = "Laws Link: ")]
        public string LawsLink { get; set; }
    }
}
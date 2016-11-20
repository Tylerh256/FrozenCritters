using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrozenCritters.Models
{
    public class Categories
    {
        public int CategoriesId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Categories Name: ")]
        public string CategoriesName { get; set; }
    }
}
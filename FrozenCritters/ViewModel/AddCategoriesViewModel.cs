using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrozenCritters.ViewModels
{
    public class AddCategoriesViewModels
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Categories Name: ")]
        public string CategoriesName { get; set; }
    }
}
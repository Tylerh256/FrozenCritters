using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrozenCritters.Models
{
    public class Products
    {
        [Key]
        public int ProductsId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Name: ")]
        public string ProductsName { get; set; }

        [Required]
        [StringLength(140)]
        [Display(Name = "Description: ")]
        public string ProductsDescription { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price: ")]
        public double ProductsPrice { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Sale Price: ")]
        public double? ProductsSalePrice { get; set; }

        [Display(Name = "Feature Sale Item: ")]
        public bool ProductsFeatureSale { get; set; }

        [Display(Name = "Feature Item: ")]
        public bool ProductsFeature { get; set; }

        [Required]
        [Display(Name = "Quantity: ")]
        public int ProductsQuantity { get; set; }

        [Display(Name = "Main Photo: ")]
        public string ProductsPhoto { get; set; }

        [Display(Name = "Alt Photo 1: ")]
        public string ProductsPhoto2 { get; set; }

        [Display(Name = "Alt Photo 2: ")]
        public string ProductsPhoto3 { get; set; }

        [Display(Name = "Alt Photo 3: ")]
        public string ProductsPhoto4 { get; set; }

        [Display(Name = "Alt Photo 4: ")]
        public string ProductsPhoto5 { get; set; }

        [Display(Name = "Category: ")]
        public int CategoriesId { get; set; }
    }
}
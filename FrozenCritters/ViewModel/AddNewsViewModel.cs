using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrozenCritters.ViewModels
{
    public class AddNewsViewModel
    {
        [Key]
        public int NewsId { get; set; }

        [Required]
        [StringLength(75)]
        [Display(Name = "News title: ")]
        public string NewsTitle { get; set; }

        [Required]
        [StringLength(140)]
        [Display(Name = "News Description: ")]
        public string NewsDescription { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Posting Date: ")]
        public DateTime NewsPostDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date: ")]
        public DateTime NewsExpirationDate { get; set; }
    }
}
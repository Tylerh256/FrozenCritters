using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrozenCritters.Models
{
    public class News
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

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Posting Date: ")]
        public DateTime NewsPostDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date: ")]
        public DateTime NewsExpirationDate { get; set; }
    }
}
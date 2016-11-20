using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrozenCritters.Models
{
    public class Photos
    {
        [Key]
        public int PhotosId { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "File: ")]
        public string PhotosFile { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Photo Name: ")]
        public string PhotosName { get; set; }

        [Required]
        [StringLength(140)]
        [Display(Name = "Photo Description: ")]
        public string PhotosDescription { get; set; }
    }
}
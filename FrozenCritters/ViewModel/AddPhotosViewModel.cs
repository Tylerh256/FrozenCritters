using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FrozenCritters.ViewModels
{
    public class AddPhotosViewModel
    {
        [Key]
        public int PhotosId { get; set; }

        [Required]
        [Display(Name = "File: ")]
        public byte[] PhotosFile { get; set; }

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
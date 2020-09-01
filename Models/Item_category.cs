using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lubricants.Models
{
    public class Item_category
    {
        [Key]
        [Required]

        [Display(Name = "ID", Prompt = "ID")]
        public int ID { get; set; }


        [Display(Name = "Category name:", Prompt = "Category name")]
        [Required]
        [MaxLength(50)]
        public string  Category_name { get; set; }

        [Display(Name = "Choose image:", Prompt = "Choose image")]
        [Required]
        [NotMapped]
        public IFormFile Category_image { get; set; }
        public string ImageURL { get; set; }
      



        //[Display(Name = "Upload Image:", Prompt = "Upload image")]
        //[Required(ErrorMessage = "Please choose profile image")]
    
        //public IFormFile Category_picture { get; set; }
    }
}

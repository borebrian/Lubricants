using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lubricants.Models
{
    public class ItemCategoryViewModel
    {
        public List<Item_category> item_Categories { set; get; }

        [Key]
        [Required]

        [Display(Name = "ID", Prompt = "ID")]
        public int ID { get; set; }
        //hapa ungeweka guid

        //[maxxlenght(50)]..na ikue string

        [Display(Name = "Category name:", Prompt = "Category name")]
        [Required]
        [MaxLength(50)]
        public string Category_name { get; set; }

        [Display(Name = "Choose image:", Prompt = "Choose image")]
        [Required]
        [NotMapped]
        public IFormFile Category_image { get; set; }
        public string ImageURL { get; set; }
    }
}

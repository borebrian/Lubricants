using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Status { get; set; }



        [Display(Name = "Upload Image:", Prompt = "Upload image")]
        [Required(ErrorMessage = "Please choose profile image")]
        public string Category_item { get; set; }
    }
}

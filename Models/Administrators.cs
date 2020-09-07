using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lubricants.Models
{
    public class Administrators
    {
        [Key]
        [Required]

        [Display(Name = "ID", Prompt = "ID")]
        public int IDT { get; set; }

        [Display(Name = "Category name:", Prompt = "Category name")]
        [Required]
        [MaxLength(50)]
        public string Category_name { get; set; }
    }
}

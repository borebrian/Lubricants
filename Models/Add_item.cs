using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lubricants.Models
{
    public class Add_item
    {
        public List<Item_category> item_Categories { set; get; }


        [Key]
        public int id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Select category", Prompt = "Category")]
        public int Category_id { get; set; }

        [Display(Name = "Item name:", Prompt = "Item name")]
        [Required]
        [MaxLength(50)]
        public string Item_name { get; set; }

        [Display(Name = "Item price:", Prompt = "Price in Ksh.")]
        [DataType(DataType.Currency)]
        [Required]
        public float Item_price { get; set; }

        [Display(Name = "Item quantity:", Prompt = "Quantity")]
        [Required]
        public int Quantity { get; set; }
        

        [Required]
        //[DataType(DataType.Date)]
        public string DateTime { get; set; }

        [ForeignKey("IDT")]
        public Item_category category { get; set; }


    }
}

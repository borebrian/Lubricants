using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lubricants.Models
{
    public class Submited_stock
    {
        [Key]
        public int id { get; set; }
        public int item_id { get; set; }
        [Required]
        //[DataType(DataType.Date)]
        public string DateTime { get; set; }
        [Required]
        public int item_sold { get; set; }
        [Required]
        public float Cash_made { get; set; }
        [Required]
        public string User_id { get; set; }

    }
}

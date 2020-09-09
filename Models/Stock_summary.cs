using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lubricants.Models
{
    public class Stock_summary
    {
        public float Item_price { get; set; }
        public string Category_name { get; set; }
        public string Item_name { get; set; }
        public int Quantity { get; set; }
        public string ImageURL { get; set; }
        public string IDT { get; set; }
        public int id { get; set; }
        public int item_sold { get; set; }
        public float Cash_made { get; set; }
        public string User_id { get; set; }
    }
}

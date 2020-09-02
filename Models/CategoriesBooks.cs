using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lubricants.Models
{
    public class CategoriesBooks
    {
        [Key]
        [MaxLength(50)]
        public string id { get; set; }
        public string CatName { get; set; }
    }
}

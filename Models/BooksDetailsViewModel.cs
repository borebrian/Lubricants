using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lubricants.Models
{
    public class BooksDetailsViewModel
    {
        public CategoriesBooks CategoriesBooks { set; get; }
        public List<CatItems> catItems { set; get; }

        [Key]
        [MaxLength(50)]
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string CatId { get; set; }//itabeba id ya iyo cat yake..
    }
}

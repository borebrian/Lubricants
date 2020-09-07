//using Covid19Tracing.Models;
using Lubricants.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fuela.DBContext
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Item_category> Items_category { get; set; }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {

        }


        public DbSet<Lubricants.Models.Add_item> Add_item { get; set; }


        public DbSet<Lubricants.Models.Submited_stock> Submited_stock { get; set; }
      


      






    }
}

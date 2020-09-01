﻿//using Covid19Tracing.Models;
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


       



    }
}
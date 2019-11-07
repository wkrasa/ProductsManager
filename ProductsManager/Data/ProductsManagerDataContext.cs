using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProductsManager.Data.Models;

namespace ProductsManager.Data
{
    public class ProductsManagerDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Data.db");
        }

        public DbSet<Product> Products { get; set; }
    }
}

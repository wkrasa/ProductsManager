using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProductsManager.Data.Models;

namespace ProductsManager.Data
{
    public static class ProductsManagerDataSeeder
    {
        public static void Seed(IServiceProvider provider)
        {
            var db = provider.GetRequiredService<ProductsManagerDataContext>();

            db.Database.EnsureCreated();

            if (!db.Products.Any())
            {
                db.Products.Add(new Product() { Name = "Milk", Price = 2.20M });
                db.Products.Add(new Product() { Name = "Bread", Price = 4.80M });
                db.Products.Add(new Product() { Name = "Butter", Price = 4.50M });

                db.SaveChanges();
            }
        }
    }
}

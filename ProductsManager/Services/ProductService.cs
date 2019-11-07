using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsManager.Data;
using ProductsManager.Data.Models;

namespace ProductsManager.Services
{
    public class ProductService: IProductService
    {
        private readonly ProductsManagerDataContext _db;

        public ProductService(ProductsManagerDataContext db)
        {
            _db = db;
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _db.Products.SingleOrDefaultAsync(x => x.Id == id);            
        }

        public async Task<Product> GetByName(string name)
        {
            return await _db.Products.SingleOrDefaultAsync(x => x.Name == name);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Guid> Save(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return product.Id;
        }

        public async Task Update(Product product)
        {
            var existingProduct = await _db.Products.SingleOrDefaultAsync(x => x.Id == product.Id);

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            await _db.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _db.Remove(product);
            await _db.SaveChangesAsync();
        }
    }
}

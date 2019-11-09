using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsManager.Data;
using ProductsManager.Data.Models;
using ProductsManager.Services.Models;

namespace ProductsManager.Services
{
    public class ProductService: IProductService
    {
        private readonly ProductsManagerDataContext _db;
        private readonly IMapper _mapper;

        public ProductService(
            ProductsManagerDataContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public ProductDTO GetById(Guid id)
        {
            var product = _db.Products.SingleOrDefault(x => x.Id == id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetByIdAsync(Guid id)
        {
            var product =  await _db.Products.SingleOrDefaultAsync(x => x.Id == id);                  

            return _mapper.Map<ProductDTO>(product);
        }

        public ProductDTO GetByName(string name)
        {
            var product = _db.Products.SingleOrDefault(x => x.Name == name);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetByNameAsync(string name)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x => x.Name == name);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            var products = await _db.Products.ToListAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<Guid> SaveAsync(CreateProductModel product)
        {
            var newProduct = new Product()
            {
                Name = product.Name,
                Price = product.Price
            };

            await _db.Products.AddAsync(newProduct);
            await _db.SaveChangesAsync();
            return newProduct.Id;
        }

        public async Task UpdateAsync(UpdateProductModel product)
        {
            var existingProduct = await _db.Products.SingleOrDefaultAsync(x => x.Id == product.Id);

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingProduct = await _db.Products.SingleOrDefaultAsync(x => x.Id == id);

            _db.Remove(existingProduct);
            await _db.SaveChangesAsync();
        }
    }
}

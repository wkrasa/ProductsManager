using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsManager.Data;
using ProductsManager.Data.Models;

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

        public async Task<ProductDTO> GetById(Guid id)
        {
            var product =  await _db.Products.SingleOrDefaultAsync(x => x.Id == id);       
            
            if(product == null)
            {
                return null;
            }

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetByName(string name)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x => x.Name == name);

            if (product == null)
            {
                return null;
            }

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var products = await _db.Products.ToListAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<Guid> Save(ProductDTO product)
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

        public async Task Update(ProductDTO product)
        {
            var existingProduct = await _db.Products.SingleOrDefaultAsync(x => x.Id == product.Id);

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            await _db.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var existingProduct = await _db.Products.SingleOrDefaultAsync(x => x.Id == id);

            _db.Remove(existingProduct);
            await _db.SaveChangesAsync();
        }
    }
}

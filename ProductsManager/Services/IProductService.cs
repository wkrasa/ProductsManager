using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProductsManager.Data.Models;
using ProductsManager.Services.Models;

namespace ProductsManager.Services
{
    public interface IProductService
    {
        ProductDTO GetById(Guid id);

        Task<ProductDTO> GetByIdAsync(Guid id);

        ProductDTO GetByName(string name);

        Task<ProductDTO> GetByNameAsync(string name);

        Task<IEnumerable<ProductDTO>> GetAllAsync();

        Task<Guid> SaveAsync(CreateProductModel product);

        Task UpdateAsync(UpdateProductModel product);

        Task DeleteAsync(Guid guid);
    }
}

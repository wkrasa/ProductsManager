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
        Task<ProductDTO> GetById(Guid id);

        Task<ProductDTO> GetByName(string name);

        Task<IEnumerable<ProductDTO>> GetAll();

        Task<Guid> Save(CreateProductModel product);

        Task Update(UpdateProductModel product);

        Task Delete(Guid guid);
    }
}

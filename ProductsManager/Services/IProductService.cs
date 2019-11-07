using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ProductsManager.Data.Models;

namespace ProductsManager.Services
{
    public interface IProductService
    {
        Task<Product> GetById(Guid id);

        Task<Product> GetByName(string name);

        Task<IEnumerable<Product>> GetAll();

        Task<Guid> Save(Product product);

        Task Update(Product product);

        Task Delete(Product product);
    }
}

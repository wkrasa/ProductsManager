using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsManager.Data;
using ProductsManager.Data.Models;

namespace ProductsManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {       
        private readonly ILogger<ProductsController> _logger;

        private readonly ProductsManagerDataContext _db;

        public ProductsController(
            ILogger<ProductsController> logger,
            ProductsManagerDataContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _db.Products;
        }
    }
}

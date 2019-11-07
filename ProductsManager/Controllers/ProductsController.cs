using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<ActionResult> Get()
        {
            var products = await _db.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("/products/{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var product = await _db.Products.SingleOrDefaultAsync(x => x.Id == id);

            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(Product product)
        {
            var existingProduct = await _db.Products.SingleOrDefaultAsync(x => x.Name == product.Name);

            if(existingProduct != null)
            {
                return BadRequest($"Product with name '{product.Name}' already exists");
            }

            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
            return Ok(product.Id);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Product product)
        {
            var existingProduct = await _db.Products.SingleOrDefaultAsync(x => x.Id == product.Id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;

                await _db.SaveChangesAsync();

                return Ok();
            }
        }

        [HttpDelete("/products/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var existingProduct = await _db.Products.SingleOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null)
            {
                return NotFound();
            }
            else
            {
                _db.Remove(existingProduct);
                await _db.SaveChangesAsync();

                return Ok();
            }
        }
    }
}

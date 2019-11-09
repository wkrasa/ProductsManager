using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using ProductsManager.Data;
using ProductsManager.Data.Models;
using ProductsManager.Services;
using ProductsManager.Services.Models;

namespace ProductsManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        private readonly IProductService _productService;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("/products/{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound($"Product with '{id}' was not found");
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProductModel product)
        {
            var result = await _productService.SaveAsync(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateProductModel product)
        {
            await _productService.UpdateAsync(product);
            return Ok();
        }

        [HttpDelete("/products/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var existingProduct = await _productService.GetByIdAsync(id);

            if (existingProduct == null)
            {
                return NotFound($"Product with '{id}' was not found");
            }
            else
            {
                await _productService.DeleteAsync(id);
                return Ok();
            }
        }
    }
}

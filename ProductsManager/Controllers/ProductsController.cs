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
            var products = await _productService.GetAll();

            return Ok(products);
        }

        [HttpGet("/products/{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var product = await _productService.GetById(id);

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
        public async Task<ActionResult> Post(Product product)
        {
            var existingProduct = await _productService.GetByName(product.Name);

            if (existingProduct != null)
            {
                return BadRequest($"Product with name '{product.Name}' already exists");
            }

            var result = await _productService.Save(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Product product)
        {
            var existingProduct = await _productService.GetById(product.Id);

            if (product == null)
            {
                return NotFound($"Product with '{product.Id}' was not found");
            }
            else
            {
                await _productService.Update(product);
                return Ok();
            }
        }

        [HttpDelete("/products/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var existingProduct = await _productService.GetById(id);

            if (existingProduct == null)
            {
                return NotFound($"Product with '{id}' was not found");
            }
            else
            {
                await _productService.Delete(existingProduct);
                return Ok();
            }
        }
    }
}

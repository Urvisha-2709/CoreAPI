using Microsoft.AspNetCore.Mvc;
using AspNetCoreWebAPI.Services;
using AspNetCoreWebAPI.Models;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            _productService.AddProduct(product);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var DeletedProduct = _productService.DeleteProduct(id);
            if (DeletedProduct == null)
            {
                return NotFound();
            }
            return Ok(DeletedProduct);
        }
    }
}

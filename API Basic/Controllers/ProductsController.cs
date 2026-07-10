using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop CMC", Price = 15000000 },
            new Product { Id = 2, Name = "Bàn phím cơ", Price = 500000 }
        };

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                              .Select(e => e.ErrorMessage)
                                              .ToList();
                return BadRequest(new { Errors = errors });
            }

            product.Id = _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
            _products.Add(product);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Errors = new[] { "ID phải là số nguyên dương." } });
            }

            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(new { Message = "Không tìm thấy sản phẩm với ID này." });
            }

            return Ok(product);
        }
    }
}
using EComm.Abstractions;
using EComm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EComm.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepository _repository;

        public ProductController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]  
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _repository.GetAllProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]  
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _repository.GetProduct(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PatchProduct(int id, Product product)
        {
            // perform some validation

            var existingProduct = await _repository.GetProduct(id);
            if (existingProduct == null) return NotFound();

            if (product.UnitPrice.HasValue) {
                existingProduct.UnitPrice = product.UnitPrice;
            }
            if (!string.IsNullOrWhiteSpace(product.ProductName)) {
                existingProduct.ProductName = product.ProductName;
            }

            await _repository.Save();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReplaceProduct(int id, Product product)
        {
            // perform some validation

            var existingProduct = await _repository.GetProduct(id);
            if (existingProduct == null) return NotFound();

            existingProduct.ProductName = product.ProductName;
            existingProduct.UnitPrice = product.UnitPrice;
            existingProduct.SupplierId = product.SupplierId;
            existingProduct.Package = product.Package;
            existingProduct.IsDiscontinued = product.IsDiscontinued;   

            await _repository.Save();

            return NoContent();
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddProduct(Product product)
        {
            // perform some validation

            await _repository.AddProduct(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var existingProduct = await _repository.GetProduct(id);
            if (existingProduct == null) return NotFound();

            bool b = await _repository.RemoveProduct(existingProduct);

            if (!b) return BadRequest(new { msg = "ref problem" });

            return NoContent();
        }
    }
}


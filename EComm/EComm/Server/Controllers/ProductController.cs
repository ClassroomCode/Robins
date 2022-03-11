using EComm.Server.DataAccess;
using EComm.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EComm.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ECommDataContext _dataContext;
        private readonly ILogger _logger;

        public ProductController(ECommDataContext dataContext, ILogger<ProductController> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProducts(bool includeSuppliers = false)
        {
            IEnumerable<Product> products = new List<Product>();

            if (includeSuppliers) {
                products = await _dataContext.Products
                    .Include(p => p.Supplier).ToArrayAsync();
            }
            else {
                products = await _dataContext.Products.ToArrayAsync();
            }
            return Ok(products);
        }

        // api/product/6
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _dataContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReplaceProduct(int id, Product product)
        {
            // perform some validation 
            if (id != product.Id) return BadRequest();

            var existing = await _dataContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (existing == null) return NotFound();

            existing.ProductName = product.ProductName;
            existing.UnitPrice = product.UnitPrice;
            existing.SupplierId = product.SupplierId;
            existing.Package = product.Package;
            existing.IsDiscontinued = product.IsDiscontinued;

            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PatchProduct(int id, Product product)
        {
            // perform some validation 
            if (id != product.Id) return BadRequest();

            var existing = await _dataContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (existing == null) return NotFound();

            if (!string.IsNullOrWhiteSpace(product.ProductName) &&
                    product.ProductName != existing.ProductName) {
                existing.ProductName = product.ProductName;
            }
            if (product.UnitPrice.HasValue && (product.UnitPrice != existing.UnitPrice)) {
                existing.UnitPrice = product.UnitPrice;
            }
            if ((product.SupplierId != 0) && product.SupplierId == existing.SupplierId) {
                existing.SupplierId = product.SupplierId;
            }
            if ((product.Package != null) && (product.Package != existing.Package)) {
                existing.Package = product.Package;
            }
            if (product.IsDiscontinued != existing.IsDiscontinued) {
                existing.IsDiscontinued = product.IsDiscontinued;
            }

            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            // do some validation (return 400)

            product.Id = 0;
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _dataContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();

            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}


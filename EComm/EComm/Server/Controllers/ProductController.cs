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
    }
}





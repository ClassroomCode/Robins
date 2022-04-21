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
    public class SupplierController : ControllerBase
    {
        private IRepository _repository;

        public SupplierController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("")]  
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllSuppliers()
        {
            var suppliers = await _repository.GetAllSuppliers();

            return Ok(suppliers);
        }
    }
}


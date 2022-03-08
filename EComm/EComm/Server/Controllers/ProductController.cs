using EComm.Server.DataAccess;
using EComm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
        private readonly ECommDataContext _dataContext;

        public ProductController(ECommDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = _dataContext.Products;

            var sp = products.Where(p => p.ProductName.StartsWith("A"));

            var sp2 = sp.Where(p => p.UnitPrice > 5);


            var retVal = await sp2.ToArrayAsync();
            
            return Ok(retVal);
        }
    }
}

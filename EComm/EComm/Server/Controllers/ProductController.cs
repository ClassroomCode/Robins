using EComm.Server.DataAccess;
using EComm.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Server.Controllers
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
        public IEnumerable<Product> GetAllProducts()
        {
            return _dataContext.Products.ToArray();
        }
    }
}

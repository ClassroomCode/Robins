using EComm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Abstractions
{
    public interface IRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Supplier>> GetAllSuppliers();

        Task<Product?> GetProduct(int id);
    }
}

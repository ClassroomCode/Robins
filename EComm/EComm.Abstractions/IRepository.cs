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
        Task<IEnumerable<Product>> GetAllProducts(bool includeSuppliers = false);
        Task<IEnumerable<Supplier>> GetAllSuppliers();

        Task<IEnumerable<Product>> GetAllProductRange(int start, bool includeSuppliers = false);

        Task<Product?> GetProduct(int id);

        Task Save();

        Task AddProduct(Product product);
        Task<bool> RemoveProduct(Product product);
    }
}

using EComm.Abstractions;
using EComm.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Infrastructure
{
    public class ECommDataContext : DbContext, IRepository
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Products.ToArrayAsync();
        }

        public Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await Suppliers.ToArrayAsync();
        }
    }
}

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
    internal class ECommDataContext : DbContext, IRepository
    {
        private string _connStr;

        public ECommDataContext(string connStr)
        {
            _connStr = connStr;
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await Products.ToArrayAsync();
        }

        public async Task<Product?> GetProduct(int id)
        {
            return await Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await Suppliers.ToArrayAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_connStr).LogTo(Console.WriteLine);
        }
    }
}

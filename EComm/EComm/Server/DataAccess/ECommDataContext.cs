using EComm.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Server.DataAccess
{
    public class ECommDataContext : DbContext
    {
        public ECommDataContext(DbContextOptions options) :
            base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Supplier> Suppliers => Set<Supplier>();
    }
}

using EComm.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Infrastructure
{
    public static class RepositoryFactory
    {
        public static IRepository CreateRepository(string connStr)
        {
            return new ECommDataContext(connStr);
        }
    }
}

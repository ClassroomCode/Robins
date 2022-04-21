using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int SupplierId { get; set; }
        public Decimal? UnitPrice { get; set; }
        public string? Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public Supplier? Supplier { get; set; }

        public string FormattedPrice
        {
            get
            {
                if (UnitPrice == 0) return "FREE";
                return string.Format("{0:C}", UnitPrice);
            }
        }
    }
}

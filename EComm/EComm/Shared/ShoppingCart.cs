using System.Collections.Generic;
using System.Linq;

namespace EComm.Shared
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            LineItems = new List<LineItem>();
        }

        public List<LineItem> LineItems { get; set; }
        public string FormattedGrandTotal => $"{LineItems.Sum(i => i.TotalCost):C}";

        public class LineItem
        {
            public LineItem(Product product)
            {
                Product = product;
            }

            public Product Product { get; set; }
            public int Quantity { get; set; }

            public decimal TotalCost => ((Product.UnitPrice == null) ? 
                0 : Product.UnitPrice.Value * Quantity);
        }
    }
}

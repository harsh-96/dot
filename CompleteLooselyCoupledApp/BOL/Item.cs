using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Item
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public double Total { get; set; }
        public Item()
        {
        }

       /* public double GetTotal()
        {

            Product product = ProductDAL.Get(name);
            double total = 0;
            if (product != null)
            {
                double unitPrice = product.UnitPrice;
                total = quantity * unitPrice; ;
                Total = total;
            }
            return total;

        }*/

    }
}

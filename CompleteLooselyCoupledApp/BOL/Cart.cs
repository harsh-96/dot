using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Cart
    {
        public List<Item> items = new List<Item>();
        public double Total { get; set; }
        public void Add(Item item)
        {
            items.Add(item);
            Total = GetTotal();
        }
        public List<Item> GetAll()
        {
            return items;

        }
        public double GetTotal()
        {
            double total = 0;

            foreach (Item item in items)
            {
                total += item.Total;
            }
            return total;

        }
        public int CreateOrder()
        {
            decimal orderTotal = 0;
            var cartItems = GetAll();

            Order myOrder = new Order();
            myOrder.OrderDate = DateTime.Now;
            myOrder.Amount = 10000;

           // myOrder.Consumer;//= CustomerDAL.Get(1);
            //OrderDAL.Insert(myOrder);
            OrderDetails orderDetails;
            //    = new OrderDetails();
           // OrderDetailsDAL.Insert(orderDetails);

            // Iterate over the items in the cart, adding the order details for each
            // Empty the shopping cart
            //  EmptyCart();
            // Return the OrderId as the confirmation number

            return myOrder.OrderId;
        }
    }
}

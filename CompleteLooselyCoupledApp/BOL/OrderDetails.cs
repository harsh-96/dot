using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class OrderDetails
    {

            private int orderDetailsId;
            private int orderId;
            private int productId;
            private int quantity;
            private float unitPrice;

            public OrderDetails()
            {
                orderDetailsId = 777;
                productId = 1;
                quantity = 4;
                orderId = 3;
                unitPrice = 500;
            }
            public int OrderID
            {
                get { return orderId; }
                set { orderId = value; }
            }
            public int OrderDetailsID
            {
                get { return orderDetailsId; }
                set { orderDetailsId = value; }
            }
            public int ProductID
            {
                get { return productId; }
                set { productId = value; }
            }
            public int Quantity
            {
                get { return quantity; }
                set { quantity = value; }
            }
            public float UnitPrice
            {
                get { return unitPrice; }
                set { unitPrice = value; }
            }

        }

    }

 

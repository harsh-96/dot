using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
  public   class OrderItem
    {
            private int id;
            private int orderId;
            private int productId;
            private int quantity;
            private double unitPrice;
            public int Id
            {
                get
                {
                    return id;
                }

                set
                {
                    id = value;
                }
            }
            public int OrderId
            {
                get
                {
                    return orderId;
                }

                set
                {
                    orderId = value;
                }
            }
            public int Quantity
            {
                get
                {
                    return quantity;
                }

                set
                {
                    quantity = value;
                }
            }
            public double UnitPrice
            {
                get
                {
                    return unitPrice;
                }

                set
                {
                    unitPrice = value;
                }
            }
            public int ProductId
            {
                get
                {
                    return productId;
                }

                set
                {
                    productId = value;
                }
            }
            public double Amt
            {
                get
                {
                    return quantity * unitPrice;
                }
            }
            public override string ToString()
            {
                return string.Format("Order Id: {0}, Product Id: {1}, Quantity: {2}, Unit Price: {3}, Amt: {4}",
        orderId, productId, quantity, unitPrice, Amt);

            }
        }
    }


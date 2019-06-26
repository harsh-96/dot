using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Order
    {
        private int orderId;
        private DateTime orderDate;
        private Customer customer = new Customer();
        private double amount;
        private List<OrderItem> orderItems = new List<OrderItem>();
        private Payment payment = new Payment();

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
        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }

            set
            {
                orderDate = value;
            }
        }
        public Customer Consumer
        {
            get
            {
                return customer;
            }

            set
            {
                customer = value;
            }
        }
        public double Amount
        {
            get
            {
                amount = 0;
                foreach (OrderItem orderItem in orderItems)
                {
                    amount += orderItem.Amt;
                }
                return amount;
            }

            set
            {
                amount = value;
            }
        }
        public List<OrderItem> OrderItems
        {
            get
            {
                return orderItems;
            }

            set
            {
                orderItems = value;
            }
        }
        public Payment PaymentInfo
        {
            get
            {
                return payment;
            }

            set
            {
                payment = value;
            }
        }
        public override string ToString()
        {
            return string.Format("Order Id: {0}, Order Date: {1}, Customer Id: {2}, Amount: {3}",
                orderId, orderDate, Consumer.CustomerId, amount);
        }
    }
}

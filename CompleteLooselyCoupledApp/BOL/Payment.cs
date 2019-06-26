using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public enum PaymentModes
    {
        CreditCard, DebitCard, NetBanking
    }
    public class Payment
    {
        private int paymentId;
        private int orderId;
        private DateTime paymentDate;
        private PaymentModes paymentMode;
        private double amount;

        public int PaymentId
        {
            get
            {
                return paymentId;
            }

            set
            {
                paymentId = value;
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
        public DateTime PaymentDate
        {
            get
            {
                return paymentDate;
            }

            set
            {
                paymentDate = value;
            }
        }
        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }
        public PaymentModes PaymentMode
        {
            get
            {
                return paymentMode;
            }

            set
            {
                paymentMode = value;
            }
        }
        public override string ToString()
        {
            return string.Format("Order Id: {0}, Payment Date: {1}, PaymentMode: {2}, Amount: {3} ",
    orderId, paymentDate, paymentMode.ToString(), amount);
        }
    }
}

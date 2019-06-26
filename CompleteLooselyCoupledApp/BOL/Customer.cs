using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Customer : Person
    {
        private int customerId;
        private string emailId;
        private string mobileNo;
        private DateTime registrationDate;
        private string password;
        private readonly string role;

        public int CustomerId
        {
            get
            {
                return customerId;
            }

            set
            {
                customerId = value;
            }
        }
        public string EmailId
        {
            get
            {
                return emailId;
            }

            set
            {
                emailId = value;
            }
        }
        public string MobileNo
        {
            get
            {
                return mobileNo;
            }

            set
            {
                mobileNo = value;
            }
        }
        public DateTime RegistrationDate
        {
            get
            {
                return registrationDate;
            }

            set
            {
                registrationDate = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }
        public string Role
        {
            get
            {
                return role;
            }
        }

        public Customer() : base()
        {
            role = "Customer";
            registrationDate = DateTime.Now;
        }
        public Customer(int customerId, string firstName, string lastName, string address, string emailId, string mobileNo) : base(firstName, lastName, address)
        {
            this.customerId = customerId;
            role = "Customer";
            registrationDate = DateTime.Now;
            this.emailId = emailId;
            this.mobileNo = mobileNo;
        }
        public Customer(int customerId, string firstName, string lastName, string address, string emailId, string mobileNo, string password) : base(firstName, lastName, address)
        {
            this.customerId = customerId;
            role = "Customer";
            registrationDate = DateTime.Now;
            this.emailId = emailId;
            this.mobileNo = mobileNo;
            this.password = password;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

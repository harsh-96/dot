using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string address;
        public int ID { get; set; }
        public Person()
        {

        }
        public Person(string firstName, string lastName, string address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
        public override string ToString()
        {
            return string.Format(@"First Name: {0}, Last Name: {1},
                    \n Address: {2}", firstName, lastName, address);
        }
    }
}

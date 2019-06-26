using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BOL;

namespace DAL
{
    public class CustomerDAL
    {
        public static  List<Customer> GetAllCustomers()
        {   List<Customer> customers = new List<Customer>();

            string conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;

            SqlConnection con = new SqlConnection(conString);
            string cmdString = "SELECT * FROM Customers";
            SqlCommand cmd = new SqlCommand(cmdString, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int customerID = int.Parse(reader["customerID"].ToString());
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    Customer cst = new Customer
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };
                    customers.Add(cst);
                }
                reader.Close();
            }
            catch (Exception exp)
            {   throw exp;    }
            finally
            { con.Close(); }
            return customers;
        }

        public static  Customer GetCustomer(int id)
        {
            Customer cst = null;

            string conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string cmdString = "SELECT * FROM Customers WHERE customerId=" + 102;

            SqlCommand cmd = new SqlCommand(cmdString, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int customerID = int.Parse(reader["customerID"].ToString());
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    cst = new Customer
                    {
                        FirstName = firstName,
                        LastName = lastName
                    };
                }
                reader.Close();
            }
            catch (Exception exp)
            { throw exp; }
            finally
            { con.Close(); }

            return cst;
        }

        public static void DeleteCustomer(int id)
        {
            string conString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string cmdString = "DELETE FROM Customers WHERE customerId=" + id;
            SqlCommand cmd = new SqlCommand(cmdString, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            { throw exp;  }
            finally
            {   con.Close(); }
        }
    }
}

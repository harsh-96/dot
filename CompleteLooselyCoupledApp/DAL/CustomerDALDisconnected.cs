using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BOL;

namespace DALDisconnected
{
    public class CustomerDAL
    {
        private static string connectionString = string.Empty;

        static CustomerDAL()
        {
           connectionString = ConfigurationManager.ConnectionStrings["conTFL"].ConnectionString;
        }
        public static List<Customer> GetAll()
        {
            List<Customer> Customers = new List<Customer>();

            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            
            string cmdString = "SELECT * FROM Customers";
            SqlCommand cmd = new SqlCommand(cmdString, con as SqlConnection);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);

                DataTable dt = ds.Tables[0];
                foreach (DataRow datarow in dt.Rows)
                {
                    string custID = datarow["Id"].ToString();
                    string firstName = datarow["FirstName"].ToString();
                    string lastName = datarow["LastName"].ToString();
                    string email = datarow["Email"].ToString();
                    string city = datarow["City"].ToString();
                    string contactNo = datarow["ContactNumber"].ToString();
                    DateTime bDate = Convert.ToDateTime(datarow["BirthDate"]);
                    Customer cust = new Customer(int.Parse(custID), firstName, lastName, city, email, contactNo, "seed");
                    Customers.Add(cust);
                }
            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return Customers;
        }
        public static Customer Get(int id)
        {
            Customer cst = null;
            List<Customer> Customers = new List<Customer>();
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
      
            string txtCommand = "SELECT * FROM Customers WHERE id=" + id;
            SqlCommand cmd = new SqlCommand(txtCommand, con as SqlConnection);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);

                DataTable dt = ds.Tables[0];

                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = dt.Columns["Id"];
                dt.PrimaryKey = keyColumns;

                DataRow datarow = ds.Tables[0].Rows.Find(id);

                string empid = datarow["Id"].ToString();
                string firstName = datarow["FirstName"].ToString();
                string lastName = datarow["LastName"].ToString();
                string email = datarow["Email"].ToString();
                string contactNo = datarow["ContactNumber"].ToString();
                string city = datarow["City"].ToString();
                DateTime bDate = Convert.ToDateTime(datarow["BirthDate"]);
                //double salary = double.Parse(datarow["Salary"].ToString());
                cst = new Customer(int.Parse(empid), firstName, lastName,city,email,contactNo,"seed");

            }
            catch (SqlException exp)
            { throw exp; }
            return cst;
        }
        public static List<Customer> GetByCity(string city)
        {
            List<Customer> Customers = new List<Customer>();
            IDbConnection con = new SqlConnection(connectionString);

            //Query
            string txtCommand = "SELECT * FROM Customers WHERE City=" + city;
            SqlCommand cmd = new SqlCommand(txtCommand, con as SqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            SqlCommandBuilder cmdBldr = new SqlCommandBuilder(da);

            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);

                DataTable dt = ds.Tables["Customers"];
                foreach (DataRow datarow in dt.Rows)
                {
                    string custID = datarow["Id"].ToString();

                    string firstName = datarow["FirstName"].ToString();
                    string lastName = datarow["LastName"].ToString();
                    string contactNo = datarow["ContactNumber"].ToString();
                    string email = datarow["Email"].ToString();
                    city = datarow["City"].ToString();
                    DateTime bDate = Convert.ToDateTime(datarow["BirthDate"]);
                    Customer cst = new Customer(int.Parse(custID), firstName, lastName, city, email, contactNo, "seed"); Customers.Add(cst);
                }

            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return Customers;
        }
        public static List<Customer> GetAllCustomers()
        {
            List<Customer> allCustomers = new List<Customer>();
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            IDbCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Customers";
            cmd.Connection = con;
            //Disconnected Data Access
            SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);

                DataTable dt = ds.Tables["Customers"];
                foreach (DataRow datarow in dt.Rows)
                {
                    string custID = datarow["Id"].ToString();

                    string firstName = datarow["firstName"].ToString();
                    string lastName = datarow["lastName"].ToString();
                    string email = datarow["Email"].ToString();
                    string contactNo = datarow["ContactNumber"].ToString();
                    string city = datarow["City"].ToString();
                    DateTime bDate = Convert.ToDateTime(datarow["BirthDate"]);
                    double salary = double.Parse(datarow["Salary"].ToString());
                    Customer cst = new Customer(int.Parse(custID), firstName, lastName, city, email, contactNo, "seed");
                    allCustomers.Add(cst);
                }
            }
            catch (SqlException exp)
            { throw exp; }

            return allCustomers;
        }
        public static Customer GetCustomer(int id)
        {
            Customer cst = null;

            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            IDbCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Customers WHERE id=@ID";

            SqlParameter param = new SqlParameter();
            param.DbType = DbType.Int16;
            param.Value = id;
            param.ParameterName = "@ID";

            cmd.Parameters.Add(param);
            cmd.Connection = con;

            SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);

                DataTable dt = ds.Tables["Customers"];
                foreach (DataRow datarow in dt.Rows)
                {
                    string custID = datarow["Id"].ToString();
                    string firstName = datarow["firstName"].ToString();
                    string lastName = datarow["lastName"].ToString();
                    string email = datarow["Email"].ToString();
                    string contactNo = datarow["ContactNumber"].ToString();
                    string city = datarow["City"].ToString();
                    DateTime bDate = Convert.ToDateTime(datarow["BirthDate"]);
                    cst = new Customer(int.Parse(custID), firstName, lastName, city, email, contactNo, "seed");
                }
            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return cst;
        }
        public static List<Customer> GetCustomersParam(string city)

        {
            List<Customer> allCustomers = new List<Customer>();
            IDbConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["TFLDBConnectionString"].ConnectionString;

            //1.Define Parameterised Query
            string cmdStr = @"select * from Customers where Address = @City";
            IDbCommand cmd = new SqlCommand();
            cmd.Connection = con as SqlConnection;
            cmd.CommandText = cmdStr;

            // 2. define parameters used in command object
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@City";
            param.DbType = DbType.String;
            param.Value = city;
            // 3. add new parameter to command object
            cmd.Parameters.Add(param);
            // get data stream

            //Disconnected Data Access
            SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }


            DataTable dt = ds.Tables["Customers"];
            foreach (DataRow datarow in dt.Rows)
            {
                string custID = datarow["Id"].ToString();
                string firstName = datarow["FirstName"].ToString();
                string lastName = datarow["LastName"].ToString();
                string email = datarow["Email"].ToString();
                string contactNo = datarow["ContactNumber"].ToString();
                city = datarow["City"].ToString();
                DateTime bDate = Convert.ToDateTime(datarow["BirthDate"]);
                double salary = double.Parse(datarow["Salary"].ToString());
                Customer cst = new Customer(int.Parse(custID), firstName, lastName, city, email, contactNo, "seed");

                allCustomers.Add(cst);
            }
            return allCustomers;
        }
        public static bool Insert(Customer cust)
        {
            bool status = false;
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;

            //1.Define Parameterised Query
            string cmdStr = "select * from Customers";
            IDbCommand cmd = new SqlCommand();
            cmd.Connection = con as SqlConnection;
            cmd.CommandText = cmdStr;

            //Disconnected Data Access
            SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();
            try
            {
                SqlCommandBuilder cmdBldr = new SqlCommandBuilder(da);


                SqlCommand deleteCommand = cmdBldr.GetDeleteCommand();
                string strDeleteCommand = deleteCommand.CommandText;

                da.Fill(ds);

                DataRow newRow = ds.Tables[0].NewRow();
                newRow["Id"] = cust.ID;
                newRow["FirstName"] = cust.FirstName;
                newRow["LastName"] = cust.LastName;
                newRow["Email"] = cust.EmailId;
                newRow["City"] = cust.Address;
                newRow["BirthDate"] = cust.RegistrationDate;

                // add new record in database

                ds.Tables[0].Rows.Add(newRow);

                //update changes back to database

                da.Update(ds);
                status = true;

            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }


            return status;

        }
        public static bool Update(Customer cstupdate)
        {
            bool status = false;

            List<Customer> allCustomers = new List<Customer>();
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            IDbCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Customers";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();
            try
            {
                SqlCommandBuilder cmdbldr = new SqlCommandBuilder(da);
                da.Fill(ds);

                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["Id"];
                ds.Tables[0].PrimaryKey = keyColumns;

                DataRow datarow = ds.Tables[0].Rows.Find(cstupdate.ID);
                datarow["FirstName"] = cstupdate.FirstName;
                datarow["LastName"] = cstupdate.LastName;
                datarow["Email"] = cstupdate.EmailId;
                datarow["City"] = cstupdate.Address;
                datarow["BirthDate"] = cstupdate.RegistrationDate;

                da.Update(ds);
            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return status;


        }
        public static bool Delete(Customer cst)
        {
            bool status = false;

            List<Customer> allCustomers = new List<Customer>();
            IDbConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            IDbCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Customers";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd as SqlCommand);
            DataSet ds = new DataSet();

            try
            {
                SqlCommandBuilder cmdbldr = new SqlCommandBuilder(da);
                da.Fill(ds);

                DataColumn[] keyColumns = new DataColumn[1];
                keyColumns[0] = ds.Tables[0].Columns["Id"];
                ds.Tables[0].PrimaryKey = keyColumns;

                DataRow datarow = ds.Tables[0].Rows.Find(cst.ID);
                datarow.Delete();
                da.Update(ds);
            }
            catch (SqlException exp)
            {
                string exceptionMessage = exp.Message;
            }
            return status;
        }
    }
}

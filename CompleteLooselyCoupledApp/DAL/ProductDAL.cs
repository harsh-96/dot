using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BOL;

namespace DAL
{
    public class ProductDAL
    {

        private static string conString = string.Empty;

       static ProductDAL()
        { //initialize connection string
            conString = ConfigurationManager.ConnectionStrings["tflgreenhouse"].ConnectionString;
        }

        public static bool Insert(Product product)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "INSERT INTO flowers (productID,title,description, picture, price, category, quantity,paymentTerm,delivery) " +
                        "VALUES (@productId,@title,@description,@picture,@price,@category,@quantity,@paymentTerm, @delivery)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@productId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@title", product.Title));
                    cmd.Parameters.Add(new SqlParameter("@description", product.Description));
                    cmd.Parameters.Add(new SqlParameter("@picture", product.ImageURL));
                    cmd.Parameters.Add(new SqlParameter("@price", product.UnitPrice));
                    cmd.Parameters.Add(new SqlParameter("@category", product.Category));
                    cmd.Parameters.Add(new SqlParameter("@quantity", product.Balance));
                    cmd.Parameters.Add(new SqlParameter("@PaymentTerm", product.PaymentTerm));
                    cmd.Parameters.Add(new SqlParameter("@Delivery", product.Delivery));
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            { throw ex; }
            return status;
        }

        public static bool Update(Product product)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "UPDATE flowers SET title=@title,description=@description, " +
                        "picture=@picture, price=@price, category=@category, quantity=@quantity, paymentTerm=@paymentTerm, delivery=@delivery " +
                        "WHERE productId=@productId";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.Add(new SqlParameter("@productId", product.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@title", product.Title));
                    cmd.Parameters.Add(new SqlParameter("@description", product.Description));
                    cmd.Parameters.Add(new SqlParameter("@picture", product.ImageURL));
                    cmd.Parameters.Add(new SqlParameter("@price", product.UnitPrice));
                    cmd.Parameters.Add(new SqlParameter("@category", product.Category));
                    cmd.Parameters.Add(new SqlParameter("@quantity", product.Balance));
                    cmd.Parameters.Add(new SqlParameter("@paymentTerm", product.PaymentTerm));
                    cmd.Parameters.Add(new SqlParameter("@delivery", product.Delivery));
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            { throw ex;}

            return status;
        }

        public static bool Delete(int productId)
        {
            bool status = false;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "DELETE FROM flowers WHERE productId=@productId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@productId", productId));
                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            { throw ex; }

            return status;
        }

        public static Product Get(int productId)
        {
            Product product = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM flowers WHERE productId=@productId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@productId", productId));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                product = new Product()
                                {
                                    ProductId = int.Parse(reader["productId"].ToString()),
                                    Title = reader["title"].ToString(),
                                    Description = reader["description"].ToString(),
                                    ImageURL = reader["picture"].ToString(),
                                    UnitPrice = float.Parse(reader["price"].ToString()),
                                    Balance = int.Parse(reader["quantity"].ToString()),
                                    PaymentTerm = reader["paymentTerm"].ToString(),
                                    Delivery = reader["delivery"].ToString(),
                                    Category = reader["category"].ToString()
                                };
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            catch (Exception ex)
            { throw ex; }
            return product;
        }

        public static Product Get(string productName)
        {
            Product product = null;
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Products WHERE Title=@ProductName";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@ProductName", productName));
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                product = new Product()
                                {
                                    ProductId = int.Parse(reader["productId"].ToString()),
                                    Title = reader["title"].ToString(),
                                    Description = reader["description"].ToString(),
                                    ImageURL = reader["picture"].ToString(),
                                    UnitPrice = float.Parse(reader["price"].ToString()),
                                    Balance = int.Parse(reader["quantity"].ToString()),
                                    PaymentTerm = reader["paymentTerm"].ToString(),
                                    Delivery = reader["delivery"].ToString(),
                                    Category = reader["category"].ToString()
                                };
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return product;
        }

        public static List<Product> GetByCategory(string category)
        {
            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM flowers WHERE category='" + category + "'"; SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Product product = new Product()
                                {
                                    ProductId = int.Parse(reader["productId"].ToString()),
                                    Title = reader["title"].ToString(),
                                    Description = reader["description"].ToString(),
                                    Category = reader["category"].ToString(),
                                    ImageURL = reader["picture"].ToString(),
                                    UnitPrice = float.Parse(reader["price"].ToString()),
                                    Balance = int.Parse(reader["quantity"].ToString()),
                                    PaymentTerm = reader["paymentTerm"].ToString(),
                                    Delivery = reader["delivery"].ToString()
                                };
                                products.Add(product);
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return products;
        }

        public static List<Product> GetAll()
        {
            conString = ConfigurationManager.ConnectionStrings["tflgreenhouse"].ConnectionString;


            List<Product> products = new List<Product>();
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM flowers";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Product product = new Product()
                                {
                                    ProductId = int.Parse(reader["productId"].ToString()),
                                    Title = reader["title"].ToString(),
                                    Description = reader["description"].ToString(),
                                    ImageURL = reader["picture"].ToString(),
                                    UnitPrice = float.Parse(reader["price"].ToString()),
                                    Balance = int.Parse(reader["quantity"].ToString()),
                                    PaymentTerm = reader["paymentTerm"].ToString(),
                                    Delivery = reader["delivery"].ToString(),
                                    Category = reader["category"].ToString()
                                };
                                products.Add(product);
                            }
                            reader.Close();
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return products;
        }
    }
}

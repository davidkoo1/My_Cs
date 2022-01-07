using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Exer10_1
{
   public static class DatabaseConnector
    {
        public static string ConnectionString = @"Data Source=DESKTOP-IQ404L4;Initial Catalog=Product;Integrated Security=true;";


        //Products
        public static void AddProduct(Product newProduct)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String query = "INSERT INTO Product VALUES (@IDProduct, @ProductName, @ProductPrice)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDProduct", newProduct.IDproduct);
                    command.Parameters.AddWithValue("@ProductName", newProduct.productName);
                    command.Parameters.AddWithValue("@ProductPrice", newProduct.price);


                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }

        }

        public static void DeleteProduct(Product deleteProduct)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "DELETE FROM Product WHERE IDProduct = @IDProduct";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDProduct", deleteProduct.IDproduct);

                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }

        }

        public static List<Product> GetProducts()
        {
            List<Product> ret = new List<Product>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "select * from Product";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Product pr1 = new Product();
                    pr1.IDproduct = dataReader.GetInt32(0);
                    pr1.productName = dataReader.GetString(1);
                    pr1.price = dataReader.GetDecimal(2);

                    ret.Add(pr1);
                }

            }
            return ret;
        }
        public static void UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String query = "UPDATE Product SET ProductName = @ProductName, ProductPrice = @ProductPrice WHERE IDProduct = @IDProduct";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDProduct", product.IDproduct);
                    command.Parameters.AddWithValue("@ProductName", product.productName);
                    command.Parameters.AddWithValue("@ProductPrice", product.price);


                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }
        }

        //Seller
        public static void AddSeller(Seller newSeller)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String query = "INSERT INTO Seller VALUES (@IDSeller, @SellerName, @TimeWork)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDSeller", newSeller.IDSeller);
                    command.Parameters.AddWithValue("@SellerName", newSeller.SellerName);
                    command.Parameters.AddWithValue("@TimeWork", newSeller.TimeWork);


                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }

        }

        public static void DeleteSeller(Seller deleteSeller)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "DELETE FROM Seller WHERE IDSeller = @IDSeller";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDSeller", deleteSeller.IDSeller);

                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }

        }
        public static List<Seller> GetSaller()
        {
            List<Seller> ret = new List<Seller>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                string GetSqlCommand;
                GetSqlCommand = "select * from Seller";

                command = new SqlCommand(GetSqlCommand, connection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Seller sl1 = new Seller();
                    sl1.IDSeller = dataReader.GetInt32(0);
                    sl1.SellerName = dataReader.GetString(1);
                    sl1.TimeWork = dataReader.GetInt32(2);

                    ret.Add(sl1);
                }

            }
            return ret;
        }
        public static void UpdateSeller(Seller seller)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String query = "UPDATE Seller SET SellerName = @SellerName, TimeWork = @TimeWork WHERE IDSeller = @IDSeller";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDSeller", seller.IDSeller);
                    command.Parameters.AddWithValue("@SellerName", seller.SellerName);
                    command.Parameters.AddWithValue("@TimeWork", seller.TimeWork);


                    connection.Open();
                    command.ExecuteNonQuery();


                }
            }
        }




    }
}

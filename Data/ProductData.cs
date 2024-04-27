using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class ProductData
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>(); // Cambiado el nombre de la lista a "products"

            using (SqlConnection connection = new SqlConnection(DataBase.connectionString))
            {
                using (SqlCommand command = new SqlCommand("USP_listarProducto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                product_id = Convert.ToInt32(reader["product_id"]),
                                name = reader["name"].ToString(),
                                price = Convert.ToDouble(reader["price"]),
                                stock = Convert.ToInt32(reader["stock"]),
                                active = Convert.ToInt32(reader["active"])
                            };
                            products.Add(product); // Se cambió "product" por "products"
                        }
                    }
                }
            }

            return products; // Se cambió "product" por "products"
        }

        public List<Product> GetByName(string name)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(DataBase.connectionString))
            {
                using (SqlCommand command = new SqlCommand("USP_listarProductoNombre", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();
                            product.product_id = Convert.ToInt32(reader["product_id"]);
                            product.name = reader["name"].ToString();
                            product.price = Convert.ToDouble(reader["price"]);
                            product.stock = Convert.ToInt32(reader["stock"]);
                            product.active = Convert.ToInt32(reader["active"]);
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
        
        


    }
}


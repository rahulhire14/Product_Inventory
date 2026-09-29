using Product_Inventory.DB_Response;
using Product_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Product_Inventory.DAL
{
    public  class ProductDAL
    {
      
           // Product product = new Product();
            public ProductDAL() { }

        Response response = new Response();
        public string CreateProduct(Product product)
            {
                try
                {

                    SqlParameter[] parameters = new SqlParameter[6];

                    parameters[0] = new SqlParameter("@Name", product.Name);
                    parameters[1] = new SqlParameter("@Category", product.Category);
                    parameters[2] = new SqlParameter("@Quantity", product.Quantity);
                    parameters[3] = new SqlParameter("@Price", product.Price);
                    parameters[4] = new SqlParameter("@SKU", product.SKU);
                    parameters[5] = new SqlParameter("@Actv_Ind", product.Actv_Ind);

                    object result = DbHelper.ExecuteScalar("sp_InsertProduct", parameters);
                    product.Product_Id = result?.ToString();

                 if (product.Product_Id != null)
                {

                    return response.ErrorMessage = product.Product_Id;
                }
                else 
                 {
                    return response.ErrorMessage = "code fat gaya";
                }
                }

            catch (Exception ex) 
            { 
                return "Error: " + ex.Message;
            }

           
        }
        public List<Product> GetProductByList(  )
        {
            DataTable dt = DbHelper.ExecuteDataTable("sp_GetProducts");

            List<Product> products = new List<Product>();

            foreach (DataRow row in dt.Rows)
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Product_Id =(string)row["Product_Id"],
                    Name = row["Name"].ToString(),
                    Category = row["Category"].ToString(),
                    SKU = row["SKU"].ToString(),
                    Quantity = Convert.ToInt32(row["Quantity"]),
                    Price = Convert.ToDecimal(row["Price"]),
                       
                };

                products.Add(product);
            }

            return products;
        }

        public List<Product> GetProductById(string productId) 
        {
         SqlParameter parameter = new SqlParameter("@Product_Id", productId);
            DataTable result = DbHelper.ExecuteDataTable( "sp_GetProducts", parameter );
            List<Product> products = new List<Product>();
            if (result != null && result.Rows.Count != 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    Product product = new Product
                    {
                        Product_Id = (string)row["Product_Id"],
                        Name = row["Name"].ToString(),
                        Category = row["Category"].ToString(),
                        SKU = row["SKU"].ToString(),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        Price = Convert.ToDecimal(row["Price"]),

                    };

                    products.Add(product);
                }

                return products;
            }
            return null;
        }
    }
}

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
    public  class StockEntryDAL
    {
        Response response = new Response();
        public string GetUpdateStock(StockEntry stockEntry , Product product)
        {
            try
            {

                SqlParameter[] parameters = new SqlParameter[4];

                parameters[0] = new SqlParameter("@Id", product.Id);
                parameters[1] = new SqlParameter("@Quantity", product.Quantity);
                parameters[2] = new SqlParameter("@Product_Id", product.Product_Id);
                parameters[3] = new SqlParameter("@Entry_Type", stockEntry.Entry_Type);

                object result = DbHelper.ExecuteScalar("sp_In_out_STOCKENTRY", parameters);
                stockEntry.Stock_Id = result?.ToString();

                if (stockEntry.Stock_Id != null)
                {

                    return response.ErrorMessage = stockEntry.Stock_Id;
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
        public List<StockEntry> GetStockEntryList()
        {
            DataTable dt = DbHelper.ExecuteDataTable("sp_GetStockEntry");

            List<StockEntry> stockEntries= new List<StockEntry>();

            foreach (DataRow row in dt.Rows)
            {
                StockEntry stockentry =  new StockEntry()
                { 
                    Id = Convert.ToInt32(row["Id"]),
                    Stock_Id = (string)row["stock_id"],
                    Product_Ref_No = row["Product_ref_No"].ToString(),
                    Entry_Type = row["Entry_type"].ToString(),
                    Quantity = row["Quantity"].ToString(),
                    Entry_Date = Convert.ToDateTime(row["Entry_date"]),
                    Remarks = row["Remarks"].ToString(),
                };

                stockEntries.Add(stockentry);
            }

            return stockEntries;
        }

        public List<Product> GetProductById(string productId)
        {
            SqlParameter parameter = new SqlParameter("@Product_Id", productId);
            DataTable result = DbHelper.ExecuteDataTable("sp_GetProducts", parameter);
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

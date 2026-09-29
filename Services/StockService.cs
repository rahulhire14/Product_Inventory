using Product_Inventory.DAL;
using Product_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Inventory.Services
{
    public class StockService
    {
        StockEntryDAL entryDAL = new StockEntryDAL(); 
        public StockService() { }
        public string GetUpdateStock(Product product ,StockEntry stockEntry) 
        {
            return entryDAL.GetUpdateStock(stockEntry, product);
        }
       public List<StockEntry> GetStockEntryList() 
        {
            return entryDAL.GetStockEntryList();
        }
    }
}

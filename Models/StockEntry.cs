using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Product_Inventory.Models
{
    public class StockEntry
    {
        public int Id { get; set; }
        public string Stock_Id { get; set; }
        public string Product_Ref_No { get; set; }
        public string Entry_Type { get; set; }
        public string Quantity { get; set; }
        public DateTime Entry_Date { get; set; }
        public string Remarks { get; set; }
    }
}

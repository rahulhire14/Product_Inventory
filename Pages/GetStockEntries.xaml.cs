using Product_Inventory.Models;
using Product_Inventory.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Product_Inventory.Pages
{
    /// <summary>
    /// Interaction logic for GetStockEntries.xaml
    /// </summary>
    public partial class GetStockEntries : Page
    {
        StockService StockService = new StockService();
        public GetStockEntries()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
         var stock_id = SearchBox.Text;
         var prdoduct_id = SearchBox2.Text;

            var entries = StockService.GetStockEntryList();
            if (!string.IsNullOrEmpty(stock_id) && !string.IsNullOrEmpty(prdoduct_id))
            {
                entries = entries.Where(x => x.Stock_Id.Contains(stock_id) && x.Product_Ref_No.Contains(prdoduct_id)).ToList();
            }
            else if (!string.IsNullOrEmpty(stock_id))
            {
                entries = entries.Where(x => x.Stock_Id.Contains(stock_id)).ToList();
            }
            else if (!string.IsNullOrEmpty(prdoduct_id))
            {
                entries = entries.Where(x => x.Product_Ref_No.Contains(prdoduct_id)).ToList();
            }
           

            StockEntryGrid.ItemsSource = entries;

        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {

        }

      
    }
}




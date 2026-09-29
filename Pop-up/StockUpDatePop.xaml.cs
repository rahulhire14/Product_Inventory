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

namespace Product_Inventory.Pop_up
{
    /// <summary>
    /// Interaction logic for StockUpDatePop.xaml
    /// </summary>
    public partial class StockUpDatePop : Window
    {
        
        private Product _product;
        StockService stockService = new StockService();
        StockEntry stockEntry = new StockEntry();
        public StockUpDatePop(Product product)
        {

            InitializeComponent();
            _product = product;

            ProductNameText.Text = product.Name;
            CurrentQtyText.Text = product.Quantity.ToString();
        }
        

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            _product.Quantity = int.Parse(QuantityBox.Text) + _product.Quantity;
            stockEntry.Entry_Type = "IN";
            stockService.GetUpdateStock(_product, stockEntry);
            MessageBox.Show($"Entry Updated {stockEntry.Stock_Id}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void RemarksBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void QuantityBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

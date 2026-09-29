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
using System.Windows.Shapes;

namespace Product_Inventory.Pop_up
{
    /// <summary>
    /// Interaction logic for OutStockPop.xaml
    /// </summary>
    public partial class OutStockPop : Window
    {
        private Product _product;
        StockService stockService = new StockService();
        StockEntry stockEntry = new StockEntry();
        public OutStockPop(Product product)
        {
            InitializeComponent();
            _product = product;
            ProductNameText.Text = product.Name;
            CurrentQtyText.Text = product.Quantity.ToString();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            int enteredQuantity = int.Parse(QuantityBox.Text);
            if (enteredQuantity > _product.Quantity)
            {
                MessageBox.Show(
                    "Entered quantity must be less than or equal to the current quantity.",
                    "Invalid Quantity",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                return;
            }
            _product.Quantity = _product.Quantity - enteredQuantity;
            stockEntry.Entry_Type = "OUT";
            stockService.GetUpdateStock(_product, stockEntry);

            MessageBox.Show($"Entry Updated {stockEntry.Stock_Id}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemarksBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void QuantityBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

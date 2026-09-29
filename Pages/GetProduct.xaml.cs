using Product_Inventory.DAL;
using Product_Inventory.Models;
using Product_Inventory.Pop_up;
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
using System.Xml.Linq;

namespace Product_Inventory.Pages
{
    /// <summary>
    /// Interaction logic for GetProduct.xaml
    /// </summary>
    public partial class GetProduct : Page
    {
        ProductService productService =new ProductService();
        Product product = new Product();
        StockService stockService = new StockService();
        public GetProduct()
        {
            InitializeComponent();
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateProduct());
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                var products = productService.GetProductByList();
                ProductTable.ItemsSource = products;
            }
            else 
            {
                 var productById = productService.GetProductById(SearchBox.Text);
                ProductTable.ItemsSource = productById;
            }
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Clear();
            CategoryBox.SelectedIndex = 0;

            LoadProducts();
        }
        private void LoadProducts()
        {
            List<Product> products = productService.GetProductByList();

            ProductTable.ItemsSource = products;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e) 
        {

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void StockIn_Click(object sender, RoutedEventArgs e) 
        {
            Button button = sender as Button;
            Product product = button.DataContext as Product;
            if (product == null)
                return;

            StockUpDatePop window = new StockUpDatePop( product); 
            window.Show();

        }
        private void StockOut_Click(object sender, RoutedEventArgs e) 
        {
            Button button = sender as Button;
            Product product = button.DataContext as Product;
            if (product == null)
                return;

            OutStockPop window = new OutStockPop(product);
            window.Show();

        }
    }
}

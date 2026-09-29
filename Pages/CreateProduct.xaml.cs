using Product_Inventory.DB_Response;
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
    /// Interaction logic for CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Page
    {
        String Message { get; set; }
        ProductService productService = new ProductService();
        Response response = new Response();
        public CreateProduct()
        {
            InitializeComponent();
        }
        private void CreateProduct_Click(object sender, RoutedEventArgs e) 
        {
            Product product = new Product()
            {
                Name = NameBox.Text,
                Category = CategoryBox.Text,
                Quantity = int.Parse(QuantityBox.Text),
                Price = int.Parse(PriceBox.Text),
                SKU = SKUBox.Text,
            };
           productService.CreateProduct(product);
           MessageBox.Show($"New Product is created {product.Product_Id}", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
           


        }
        private void CancelProduct_Click(object sender, RoutedEventArgs e) 
        {
            
            NavigationService.Navigate(new HomePage());

        }
    }
}

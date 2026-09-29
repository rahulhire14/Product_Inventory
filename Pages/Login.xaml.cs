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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        public Login()
        {
            InitializeComponent();
        }
        public string ErrorMessage { get; set; }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string UserName = UsernameBox.Text;
            string Password = PasswordBox.Password;

            if (!string.IsNullOrEmpty(UserName))
            {
                if (UserName == "admin" && Password == "1234") 
                {
                    NavigationService.Navigate(new HomePage());
                }
                else
                {
                    ErrorMessage = "Invalid username or password.";
                }
            }
        }
    }
}

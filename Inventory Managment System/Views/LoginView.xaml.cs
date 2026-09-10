using Inventory_Managment_System.Model;
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

namespace Inventory_Managment_System.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        InventoryDBContext db = new InventoryDBContext();
        public LoginView()
        {
            InitializeComponent();
            UserNameBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = db.Users.Find(UserNameBox.Text);
            if (user != null)
            {
                if (user.Password == PasswordBox.Password)
                { 
                    MainWindow MW = new MainWindow();
                    Hide();
                    SessionManager.SetUser(user);
                    MW.ShowDialog();
                    Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Login Faild", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("No User Found", "Login Faild", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            UserNameBox.Clear();
            PasswordBox.Clear();
        }
    }
}

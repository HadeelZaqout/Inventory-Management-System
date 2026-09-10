using Inventory_Managment_System.ViewModel;
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
    /// Interaction logic for AddSupplyView.xaml
    /// </summary>
    public partial class AddSupplyView : Window
    {
        AddSupplyViewModel viewModel;
        public AddSupplyView()
        {
            InitializeComponent();
            viewModel = new AddSupplyViewModel();
            this.DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if(tb.Text == "0")
            {
                tb.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "0";
            }
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "0")
            {
                tb.Text = "";
            }
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Text = "0";
            }
        }
    }
}

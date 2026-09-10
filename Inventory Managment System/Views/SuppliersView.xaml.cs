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
    /// Interaction logic for SuppliersView.xaml
    /// </summary>
    /// 
    public partial class SuppliersView : Window
    {
        SuppliersViewModel viewModel;

        public SuppliersView()
        {
            InitializeComponent();
            viewModel = new SuppliersViewModel();
            this.DataContext = viewModel;
        }
    }
}

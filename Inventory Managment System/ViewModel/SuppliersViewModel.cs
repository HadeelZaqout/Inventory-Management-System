using Inventory_Managment_System.Commands;
using Inventory_Managment_System.Migrations;
using Inventory_Managment_System.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Supplier = Inventory_Managment_System.Model.Supplier;


namespace Inventory_Managment_System.ViewModel
{
    public class SuppliersViewModel : BaseViewModel
    {
        private ObservableCollection<Supplier> suppliers;
        public ObservableCollection<Supplier> Suppliers
        {
            get { return suppliers; }
            set
            {
                suppliers = value;
                OnPropertyChanged(nameof(Suppliers));
            }
        }

        private Supplier selectedSupplier;
        public  Supplier SelectedSupplier
        {
            get {return selectedSupplier;  }
            set { selectedSupplier = value;
                if (value != null) {
                   Name = value.Name;
                   Phone = value.Phone;
                   Address = value.Address;
                }
                OnPropertyChanged(nameof(SelectedSupplier));}
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public ICommand SaveCommand { get; }
        public ICommand UpdateCommand { get; }

        public SuppliersViewModel()
        {
            Name = "";
            Phone = "";
            Address = "";
            SaveCommand = new RelayCommands(SaveSupplier, CanSaveSupplier);
            UpdateCommand = new RelayCommands(UpdateSupplier, CanUpdateSupplier);
            LoadSuppliers();
        }
        private bool CanSaveSupplier(object obj)
        {
            return !string.IsNullOrEmpty(Name) && SessionManager.LoggedInUser.PremissionLevel > 1;
        }

        private void SaveSupplier(object obj)
        {
            Supplier supplier = new Supplier
            {
                Name = Name,
                Phone = Phone,
                Address= Address,
            };
            using (var context = new InventoryDBContext())
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
               
            }
            ClearFields();
            LoadSuppliers();
        }
       
        private bool CanUpdateSupplier(object obj)
        {
            return SelectedSupplier != null && !string.IsNullOrEmpty(Name) && SessionManager.LoggedInUser.PremissionLevel > 1;
        }

        private void UpdateSupplier(object obj)
        {
            InventoryDBContext db = new InventoryDBContext();
            var supplier = db.Suppliers.Find(SelectedSupplier.SupplierId);
            if (supplier != null)
            {
                supplier.Name = Name;
                supplier.Phone = Phone;
                supplier.Address = Address;
                db.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            ClearFields();
            LoadSuppliers();
        }
        public void LoadSuppliers()
        {
            InventoryDBContext db = new InventoryDBContext();
            Suppliers = new ObservableCollection<Supplier>(db.Suppliers);
        }

        private void ClearFields()
        {
            Name = "";
            Phone = "";
            Address = "";
        }
    }
}

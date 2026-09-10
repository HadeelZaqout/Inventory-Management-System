using Inventory_Managment_System.Commands;
using Inventory_Managment_System.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Inventory_Managment_System.ViewModel
{
    public class ItemsViewModel : BaseViewModel
    {
        public string _name;
        public string Name { 
            get { return _name; }
            set { 
                if (value.Contains("_"))
                {
                    MessageBox.Show("UnderScore is not allowed !");
                    value = value.Replace("_", " ");
                }
                _name = value;
                OnPropertyChanged(nameof(Name)); }
        }

        public string _details;
        public string Details
        {
            get { return _details; }
            set { _details = value; OnPropertyChanged(nameof(Details)); }
        }

        public double _price;
        public double Price
        {
            get { return _price; }
            set { _price = value; OnPropertyChanged(nameof(Price)); }
        }

        public string _measuringUnit;
        public string MeasuringUnit
        {
            get { return _measuringUnit; }
            set { _measuringUnit = value; OnPropertyChanged(nameof(MeasuringUnit)); }
        }

        public double _reOrderLevel;
        public double ReOrderLevel
        {
            get { return _reOrderLevel; }
            set { _reOrderLevel = value; OnPropertyChanged(nameof(ReOrderLevel)); }
        }

        public ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value; OnPropertyChanged(nameof(Items));
            }
        }

        public Item _selectedItem;
        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value; 
                if (value != null) 
                {
                    Name = value.Name;
                    Details = value.Details;
                    Price = value.Price;
                    MeasuringUnit = value.MeasuringUnit;
                    ReOrderLevel = value.ReOrderLevel;
                }
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public ICommand SaveCommand { get; }
        public ICommand UpdateCommand { get; }

        public ItemsViewModel() 
        {
            Name = "";
            Details = "";
            Price = 0 ;
            MeasuringUnit = "";
            ReOrderLevel = 0 ;

            SaveCommand = new RelayCommands(SaveItem, CanSaveItem);
            UpdateCommand = new RelayCommands(UpdateItem, CanUpdateItem);
            LoadItems();
        }

        private bool CanSaveItem(object obj)
        {
            return !string .IsNullOrEmpty(Name) && Price > 0 && SessionManager.LoggedInUser.PremissionLevel > 1;
        }

        private void SaveItem(object obj)
        {
            Item item = new Item
            {
                Name = Name,
                Details = Details,
                Price = Price,
                MeasuringUnit = MeasuringUnit,
                ReOrderLevel = ReOrderLevel
            };
            InventoryDBContext db = new InventoryDBContext();
            db.Items.Add(item);
            db.SaveChanges();
            ClearFields();
            LoadItems();
        }

        private bool CanUpdateItem(object obj)
        {
            return SelectedItem != null && !string.IsNullOrEmpty(Name) && Price > 0 && SessionManager.LoggedInUser.PremissionLevel > 1;
        }

        private void UpdateItem(object obj)
        {
            InventoryDBContext db = new InventoryDBContext();
            Item item = db.Items.Find(SelectedItem.ItemId);
            if (item != null)
            {
                item.Name = Name;
                item.Details = Details;
                item.Price = Price;
                item.MeasuringUnit = MeasuringUnit;
                item.ReOrderLevel = ReOrderLevel;
                db.SaveChanges();
            }
            ClearFields();
            LoadItems();
        }
        public void LoadItems() 
        {
            InventoryDBContext db = new InventoryDBContext();
            Items = new ObservableCollection<Item>(
                db.Items.ToList()
                .Select(i =>
                {
                    i.StockValue = db.Stocks.Where(s => s.ItemId == i.ItemId).Select(s => s.StockValue).DefaultIfEmpty(0).Sum();
                    return i;
                }
                ).ToList()
                );
        }
        private void ClearFields()
        {
            Name = "";
            Details = "";
            Price = 0;
            MeasuringUnit = "";
            ReOrderLevel = 0;
        }

    }
}

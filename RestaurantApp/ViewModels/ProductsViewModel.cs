using RestaurantApp.Models;
using RestaurantApp.Services;
using RestaurantApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RestaurantApp.ViewModels
{
    internal class ProductsViewModel : BaseViewModel
    {
        private string tableName;
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public Table _table;

        private string _UserName;
        public string UserName
        {
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserName;
            }
        }

        private int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserCartItemsCount;
            }
        }

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<DishItem> LatestDishItems { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command LogOutCommand { get; set; }
        public ProductsViewModel(Table table)
        {
            _table = table;

            var _userName = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(_userName))
                UserName = "Guest";
            else
                UserName = _userName;

            UserCartItemsCount = new CartItemService().GetUserCartCount(_table == null ? 0 : _table.TableId);
            Categories = new ObservableCollection<Category>();
            LatestDishItems = new ObservableCollection<DishItem>();

            ViewCartCommand = new Command(async () => await ViewCartAsync());
            LogOutCommand = new Command(async () => await LogOutAsync());



            GetCategories();
            GetLatestItems();

        }

        private async Task LogOutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogOutView(_table));
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView(_table));
        }

        private async void GetLatestItems()
        {
            var info = await new DishItemService().GetLatestDishItemsAsync();

            foreach (var dish in info)
            {
                LatestDishItems.Add(dish);
            }
        }

        private async void GetCategories()
        {
            var info = await new CategoryInfoService().GetCategoriesAsync();
            Categories.Clear();

            foreach (var category in info)
            {
                Categories.Add(category);
            }
        }
    }
}

using RestaurantApp.Models;
using RestaurantApp.Services;
using RestaurantApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RestaurantApp.ViewModels
{
    internal class LogOutViewModel : BaseViewModel
    {
        private int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            get { return _UserCartItemsCount; }
            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }
        }

        private bool _IsCartExist;
        public bool IsCartExist
        {
            get { return _IsCartExist; }
            set
            {
                _IsCartExist = value;
                OnPropertyChanged();
            }
        }
        public Table _table;
        public Command LogOutCommand { get; set; }
        public Command GoToCartCommand { get; set; }

        public LogOutViewModel(Table table)
        {
            _table = table;
            UserCartItemsCount = new CartItemService().GetUserCartCount(table.TableId);
            IsCartExist = (UserCartItemsCount > 0) ? true : false;
            LogOutCommand = new Command(async () => await LogOutUserAsync());
            GoToCartCommand = new Command(async () => await GoToCartAsync());
        }

        private async Task GoToCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView(_table));
        }

        private async Task LogOutUserAsync()
        {
            var cartItemService = new CartItemService();
            cartItemService.RemoveItemsFromCart(_table.TableId);
            Preferences.Remove("Username");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());
        }
    }
}

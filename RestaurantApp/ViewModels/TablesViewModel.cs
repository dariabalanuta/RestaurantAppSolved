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
    internal class TablesViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        ProductsViewModel productsViewModel;
        public ObservableCollection<Table> Tables { get; set; }
        public Command ViewTableCommand { get; set; }
        public Command LogOutCommand { get; set; }


        public TablesViewModel(Table table)
        {
            productsViewModel = new ProductsViewModel(table);

            var _userName = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(_userName))
                UserName = "Guest";
            else
                UserName = _userName;

            var con = DependencyService.Get<ISQLite>().GetConnection();
            Tables = new ObservableCollection<Table>();

            LogOutCommand = new Command(async () => await LogOutAsync());

            GetTables();

        }

        private async Task LogOutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogOutView(productsViewModel._table));
        }

        private async void GetTables()
        {
            var info = await new TableService().GetTableAsync();
            Tables.Clear();
            var con = DependencyService.Get<ISQLite>().GetConnection();
            var items = con.Table<CartItem>();
            foreach (var table in info)
            {
                if (items.Where(x => x.tableId == table.TableId).Count() > 0)
                {
                    table.IsBusy = true;
                }
                Tables.Add(table);
            }
        }
    }
}

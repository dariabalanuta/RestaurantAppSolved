using RestaurantApp.Models;
using RestaurantApp.Services;
using RestaurantApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.ViewModels
{
    internal class CartViewModel : BaseViewModel
    {
        public ObservableCollection<UserCartItem> CartItems { get; set; }
        private decimal _TotalCost;
        public decimal TotalCost
        {
            get { return _TotalCost; }
            set
            {
                _TotalCost = value;
                OnPropertyChanged();
            }
        }
        public Table _table;

        public Command PlaceOrderCommand { get; set; }

        public CartViewModel(Table table)
        {
            _table = table;
            CartItems = new ObservableCollection<UserCartItem>();
            LoadItems(table.TableId);
            PlaceOrderCommand = new Command(async () => await PlaceOrderAsync());
        }
        private async Task PlaceOrderAsync()
        {
            var id = await new OrderService().PlaceOrderAsync(_table.TableId) as string;
            RemoveItemsFromCart(_table.TableId);
            await Application.Current.MainPage.Navigation.PushModalAsync(new OrderView(id, _table));
        }

        private void RemoveItemsFromCart(int tableId)
        {
            var CIS = new CartItemService();
            CIS.RemoveItemsFromCart(tableId);
        }

        private void LoadItems(int id)
        {
            var con = DependencyService.Get<ISQLite>().GetConnection();
            var items = con.Table<CartItem>().Where(x => x.tableId == id).ToList();
            CartItems.Clear();
            foreach (var item in items)
            {
                CartItems.Add(new UserCartItem()
                {
                    CartItemId = item.CartItemId,
                    ProductId = item.ProductId,
                    CartItemName = item.ProductName,
                    CartItemPrice = item.ProductPrice,
                    CartItemQuantity = item.ProductQuantity,
                    CartItemCost = item.ProductPrice * item.ProductQuantity,
                    tableId = item.tableId
                });
                TotalCost += (item.ProductPrice * item.ProductQuantity);
            }
        }
    }
}

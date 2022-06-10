using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Models;
using RestaurantApp.Views;
using Xamarin.Forms;

namespace RestaurantApp.ViewModels
{
    public class ProductsDetailsViewModel : BaseViewModel
    {
        private Table _table { get; set; }
        private DishItem _SelectedDishItem;
        public DishItem SelectedDishItem
        {
            get { return _SelectedDishItem; }
            set { _SelectedDishItem = value; OnPropertyChanged(); }

        }

        public int _tableName;

        private int _TotalQuantity;
        public int TotalQuantity
        {
            get { return _TotalQuantity; }
            set
            {
                _TotalQuantity = value;
                if (this._TotalQuantity < 0)
                    this._TotalQuantity = 0;
                if (this._TotalQuantity > 10)
                    this._TotalQuantity -= 1;
                OnPropertyChanged();

            }

        }

        public Command IncrementOrderCommand { get; set; }
        public Command DecrementOrderCommand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command ViewCartCommand { get; set; }
        public Command HomeCommand { get; set; }

        public ProductsDetailsViewModel(DishItem dishItem, Table table)
        {
            SelectedDishItem = dishItem;
            TotalQuantity = 0;
            _table = table;
            IncrementOrderCommand = new Command(() => IncrementOrder());
            DecrementOrderCommand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());
            ViewCartCommand = new Command(async () => await ViewCartAsync());
            HomeCommand = new Command(async () => await GoHomeAsync());

        }

        private async Task GoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new TablesView(_table));
        }


        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView(_table));
        }

        private void AddToCart()
        {
            var con = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                CartItem cartItem = new CartItem()
                {
                    ProductId = SelectedDishItem.DishID,
                    ProductName = SelectedDishItem.DishName,
                    ProductPrice = SelectedDishItem.DishPrice,
                    ProductQuantity = TotalQuantity,
                    tableId = _tableName
                };
                var item = con.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.ProductId == SelectedDishItem.DishID && c.tableId == _table.TableId);
                if (item == null)
                {
                    con.Insert(cartItem);
                }
                else
                {
                    item.ProductQuantity += TotalQuantity;
                    con.Update(item);
                }
                con.Commit();
                var q = con.Table<CartItem>().ToList();
                con.Close();
                Application.Current.MainPage.DisplayAlert("Cart", "Selected Item Added to Cart", "OK");
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("eError", ex.Message, "OK");
            }
            finally
            {
                con.Close();
            }
        }

        private void DecrementOrder()
        {
            TotalQuantity--;
        }

        private void IncrementOrder()
        {
            TotalQuantity++;
        }
    }
}

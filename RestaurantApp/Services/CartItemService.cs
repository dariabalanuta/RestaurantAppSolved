using RestaurantApp.Models;
using RestaurantApp.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RestaurantApp.Services
{
    internal class CartItemService
    {
        public int GetUserCartCount(int tableId)
        {
            var con = DependencyService.Get<ISQLite>().GetConnection();
            var q = con.Table<CartItem>().ToList();
            var count = con.Table<CartItem>().Where(x => x.tableId == tableId).Count();
            con.Close();
            return count;
        }

        public void RemoveItemsFromCart(int tableId)
        {
            var con = DependencyService.Get<ISQLite>().GetConnection();
            var items = con.Table<CartItem>().Where(x => x.tableId == tableId).ToList();

            con.Table<CartItem>().Delete(x => x.tableId == tableId);

            //con.DeleteAll<CartItem>();
            con.Commit();
            con.Close();
        }

    }
}

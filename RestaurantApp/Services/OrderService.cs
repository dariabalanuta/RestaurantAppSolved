using Firebase.Database;
using Firebase.Database.Query;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RestaurantApp.Services
{
    internal class OrderService
    {
        FirebaseClient client;
        public OrderService()
        {
            client = new FirebaseClient("https://restaurantapp-5c95a-default-rtdb.europe-west1.firebasedatabase.app/");

        }
        public async Task<string> PlaceOrderAsync(int tableId)
        {
            var con = DependencyService.Get<ISQLite>().GetConnection();
            var data = con.Table<CartItem>().Where(x => x.tableId == tableId).ToList();

            var orderId = Guid.NewGuid().ToString();
            var uname = Preferences.Get("Username", "Guest");

            decimal totalCost = 0;

            foreach (var item in data)
            {
                OrderDetails orderDetails = new OrderDetails()
                {
                    OrderId = orderId,
                    OrderDetailId = Guid.NewGuid().ToString(),
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    ProductQuantity = item.ProductQuantity,
                    Price = item.ProductPrice,
                    TableId = item.tableId
                };
                totalCost += item.ProductPrice * item.ProductQuantity;
                await client.Child("OrderDetails").PostAsync(orderDetails);
                tableId = item.tableId;
            }

            await client.Child("Orders").PostAsync(
                new Order()
                {
                    OrderId = orderId,
                    Username = uname,
                    OrderTotalCost = totalCost,
                    TableId = tableId
                });
            return orderId;

        }

    }
}

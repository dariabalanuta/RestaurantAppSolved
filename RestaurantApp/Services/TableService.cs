using Firebase.Database;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    internal class TableService
    {
        FirebaseClient client;
        public TableService()
        {
            client = new FirebaseClient("https://restaurantapp-5c95a-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<Table>> GetTableAsync()
        {
            var tables = (await client.Child("Tables")
                .OnceAsync<Table>())
                .Select(t => new Table
                {
                    TableId = t.Object.TableId,
                    TableName = t.Object.TableName,
                    IsBusy = t.Object.IsBusy
                }).ToList();
            return tables;
        }
    }
}

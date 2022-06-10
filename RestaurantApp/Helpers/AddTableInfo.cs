using Firebase.Database;
using Firebase.Database.Query;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.Helpers
{
    public class AddTableInfo
    {

        FirebaseClient client;
        public List<Table> Tables { get; set; }
        public AddTableInfo()
        {
            client = new FirebaseClient("https://restaurantapp-5c95a-default-rtdb.europe-west1.firebasedatabase.app/");
            Tables = new List<Table>()
            {
                new Table()
                {
                    TableId = 1,
                    TableName = "1"
                },
                new Table()
                {
                    TableId = 2,
                    TableName = "2"
                },
                new Table()
                {
                    TableId = 3,
                    TableName = "3"
                },
                new Table()
                {
                    TableId = 4,
                    TableName = "4"
                },
                new Table()
                {
                    TableId = 5,
                    TableName = "5"
                },
                new Table()
                {
                    TableId = 6,
                    TableName = "6"
                },
                new Table()
                {
                    TableId = 7,
                    TableName = "7"
                },
                new Table()
                {
                    TableId = 8,
                    TableName = "8"
                },

            };
            
        }

        public async Task AddTableAsync()
        {
            try
            {
                foreach (var table in Tables)
                {
                    await client.Child("Tables").PostAsync(new Table()
                    {
                        TableId= table.TableId,
                        TableName= table.TableName,

                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }


    }
}

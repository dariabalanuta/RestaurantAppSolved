using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Helpers;
using RestaurantApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void btnReformCategories_Clicked(object sender, EventArgs e)
        {
            var addCatInfo = new AddCategoryInfo();
            await addCatInfo.AddCategoryAsync();
        }

        private async void btnReformProducts_Clicked(object sender, EventArgs e)
        {
            var addDishInfo = new AddDishItemInfo();
            await addDishInfo.AddDishItemAsync();
        }


        private void btnCart_Clicked(object sender, EventArgs e)
        {
            var createCartTable = new CreateCartTable();
            if (createCartTable.CreatTable())
                DisplayAlert("Success", "Cart Table Created", "OK");
            else
                DisplayAlert("Error", "Error while creating table", "OK");
        }

        private async void btnTable_Clicked(object sender, EventArgs e)
        {
            {
                var addTableInfo = new AddTableInfo();
                await addTableInfo.AddTableAsync();
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestaurantApp.Views;
using RestaurantApp.Models;

namespace RestaurantApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderView : ContentPage
    {
        private Table _table;

        public OrderView(string id, Table table)
        {
            InitializeComponent();
            _table = table;
            LabelName.Text = "Welcome" + Preferences.Get("Username", "Guest") + ",";
            LabelOrderID.Text = id;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ProductsView(_table));
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
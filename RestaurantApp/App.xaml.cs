using RestaurantApp.Models;
using RestaurantApp.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //MainPage = new TablesView();
            MainPage = new LoginView();
            //MainPage = new NavigationPage(new SettingsPage());
            //MainPage = new ProductsView();
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

using RestaurantApp.Models;
using RestaurantApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestaurantApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TablesView : ContentPage
    {
        TablesViewModel tablesViewModel;
        public TablesView(Table table)
        {
            InitializeComponent();
            tablesViewModel = new TablesViewModel(table);
            this.BindingContext = tablesViewModel;
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var table = e.CurrentSelection.FirstOrDefault() as Table;
            if (table == null)
                return;
            await Navigation.PushModalAsync(new ProductsView(table));
            ((CollectionView)sender).SelectedItem = null;

        }
    }
}
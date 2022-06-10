using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RestaurantApp.Views;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestaurantApp.ViewModels;

namespace RestaurantApp.Views
{
    public partial class ProductsView : ContentPage
    {
        Table table;
        public ProductsView(Table _table)
        {
            InitializeComponent();
            table = _table;
            BindingContext = new ProductsViewModel(table);
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var category = e.CurrentSelection.FirstOrDefault() as Category;
            if (category == null)
                return;

            await Navigation.PushModalAsync(new CategoryView(category, table));
            ((CollectionView)sender).SelectedItem = null;

        }
    }
}
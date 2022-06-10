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
    public partial class ProductsDetailsView : ContentPage
    {
        ProductsDetailsViewModel productsDetailsViewModel;
        public ProductsDetailsView(DishItem dishItem, Table _table)//выбрал блюдо
        {
            InitializeComponent();
            productsDetailsViewModel = new ProductsDetailsViewModel(dishItem, _table);
            this.BindingContext = productsDetailsViewModel;
            productsDetailsViewModel._tableName = _table.TableId;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
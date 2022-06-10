using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestaurantApp.ViewModels;

namespace RestaurantApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryView : ContentPage
    {
        CategoryViewModel categoryViewModel;
        public CategoryView(Category category, Table table)//выбор категории
        {
            InitializeComponent();
            categoryViewModel = new CategoryViewModel(category, table);
            this.BindingContext = categoryViewModel;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
        //выбор блюда
        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.CurrentSelection.FirstOrDefault() as DishItem;
            if (selectedItem == null)
                return;
            await Navigation.PushModalAsync(new ProductsDetailsView(selectedItem, categoryViewModel.Table));
            ((CollectionView)sender).SelectedItem = null;
        }


    }
}
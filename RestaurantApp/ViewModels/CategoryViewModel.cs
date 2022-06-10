using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using RestaurantApp.Models;
using RestaurantApp.Services;

namespace RestaurantApp.ViewModels
{
    internal class CategoryViewModel : BaseViewModel
    {
        private Category _SelectedCategory;
        public Category SelectedCategory
        {
            set
            {
                _SelectedCategory = value;
                OnPropertyChanged();
            }
            get { return _SelectedCategory; }

        }

        public Table Table;

        public ObservableCollection<DishItem> DishItemsByCategory { get; set; }
        private int _TotalDishCount;
        public int TotalDishCount
        {
            get { return _TotalDishCount; }
            set { _TotalDishCount = value; OnPropertyChanged(); }
        }

        public CategoryViewModel(Category category, Table table)
        {
            SelectedCategory = category;
            Table = table;
            DishItemsByCategory = new ObservableCollection<DishItem>();
            GetDishItems(category.CategoryId);
        }

        private async void GetDishItems(int categoryId)
        {
            var info = await new DishItemService().GetDishItemsByCategoryAsync(categoryId);
            DishItemsByCategory.Clear();
            foreach (var dish in info)
            {
                DishItemsByCategory.Add(dish);
            }
            TotalDishCount = DishItemsByCategory.Count;

        }
    }
}

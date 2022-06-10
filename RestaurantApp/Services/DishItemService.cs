using Firebase.Database;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    internal class DishItemService
    {
        FirebaseClient client;
        public DishItemService()
        {
            client = new FirebaseClient("https://restaurantapp-5c95a-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<DishItem>> GetDishItemsAsync()
        {
            var dishItems = (await client.Child("DishItems")
                .OnceAsync<DishItem>())
                .Select(dish => new DishItem
                {
                    DishID = dish.Object.DishID,
                    CategoryId = dish.Object.CategoryId,
                    DishImage = dish.Object.DishImage,
                    DishName = dish.Object.DishName,
                    DishDescription = dish.Object.DishDescription,
                    DishRating = dish.Object.DishRating,
                    DishGramm = dish.Object.DishGramm,
                    DishCalories = dish.Object.DishCalories,
                    DishPrepareTime = dish.Object.DishPrepareTime,
                    DishPrice = dish.Object.DishPrice,
                    
                }).ToList();
            return dishItems;
        }

        public async Task<ObservableCollection<DishItem>> GetDishItemsByCategoryAsync(int categoryID)
        {
            var dishItemsByCategory = new ObservableCollection<DishItem>();
            var dishes = (await GetDishItemsAsync()).Where(d => d.CategoryId == categoryID).ToList();
            foreach (var dish in dishes)
            {
                dishItemsByCategory.Add(dish);
            }
            return dishItemsByCategory;

        }

        public async Task<ObservableCollection<DishItem>> GetLatestDishItemsAsync()
        {
            var latestDishItems = new ObservableCollection<DishItem>();
            var dishes = (await GetDishItemsAsync()).OrderByDescending(d => d.DishID).Take(10);
            foreach (var dish in dishes)
            {
                latestDishItems.Add(dish);
            }
            return latestDishItems;
        }
    }
}

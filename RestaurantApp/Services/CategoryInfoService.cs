using Firebase.Database;
using RestaurantApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Services
{
    internal class CategoryInfoService
    {
        FirebaseClient client;
        public CategoryInfoService()
        {
            client = new FirebaseClient("https://restaurantapp-5c95a-default-rtdb.europe-west1.firebasedatabase.app/");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = (await client.Child("Categories")
                .OnceAsync<Category>())
                .Select(c => new Category
                {
                    CategoryId = c.Object.CategoryId,
                    CategoryName = c.Object.CategoryName,  
                    CategoryPoster = c.Object.CategoryPoster,
                    CategoryImageUrl = c.Object.CategoryImageUrl,
                }).ToList();
            return categories;
        }
    }
}

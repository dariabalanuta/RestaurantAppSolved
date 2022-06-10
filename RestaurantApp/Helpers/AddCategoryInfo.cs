using Firebase.Database;
using Firebase.Database.Query;
using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RestaurantApp.Helpers
{
    public class AddCategoryInfo
    {
        public List<Category> Categories { get; set; }

        FirebaseClient client;
        public AddCategoryInfo()
        {
            client = new FirebaseClient("https://restaurantapp-5c95a-default-rtdb.europe-west1.firebasedatabase.app/");
            Categories = new List<Category>()
            {
                new Category() {
                    CategoryId = 1,
                    CategoryName = "Snacks",
                    CategoryPoster = "iconsnack.jpg",
                    CategoryImageUrl = "snack.png"
                    },
                new Category() {
                    CategoryId = 2,
                    CategoryName = "Salads",
                    CategoryPoster = "iconsalad.jpg",
                    CategoryImageUrl = "salad.png"
                    },
                new Category() {
                    CategoryId = 3,
                    CategoryName = "Soups",
                    CategoryPoster = "iconsoup.jpg",
                    CategoryImageUrl = "soup.png"
                    },
                new Category() {
                    CategoryId = 4,
                    CategoryName = "Main Dishes",
                    CategoryPoster = "iconmaindish.jpg",
                    CategoryImageUrl = "maindish.png"
                    },
                new Category() {
                    CategoryId = 5,
                    CategoryName = "Garnish",
                    CategoryPoster = "icongarnish.jpg",
                    CategoryImageUrl = "garnish.png"
                    },
                new Category() {
                    CategoryId = 6,
                    CategoryName = "Desserts",
                    CategoryPoster = "icondessert.jpg",
                    CategoryImageUrl = "dessert.png"
                    },
                new Category() {
                    CategoryId = 7,
                    CategoryName = "Drinks",
                    CategoryPoster = "icondrinks.jpg",
                    CategoryImageUrl = "drinks.png"
                    },
            };
        }

        public async Task AddCategoryAsync()
        {
            try
            {
                foreach (var category in Categories)
                {
                    await client.Child("Categories").PostAsync(new Category()
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        CategoryPoster = category.CategoryPoster,
                        CategoryImageUrl = category.CategoryImageUrl

                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }

    }
}

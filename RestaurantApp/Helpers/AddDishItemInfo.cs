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
    public class AddDishItemInfo
    {
        public List<DishItem> DishItems { get; set; }

        FirebaseClient client;

        public AddDishItemInfo()
        {
            client = new FirebaseClient("https://restaurantapp-5c95a-default-rtdb.europe-west1.firebasedatabase.app/");
            DishItems = new List<DishItem>()
            {
                new DishItem()
                {
                    DishID = 1,
                    CategoryId = 1,
                    DishImage = "brusscheta.jpg",
                    DishName = "Brusscheta with salmon",
                    DishDescription = "A delicious, fancier twist on the classic bruschetta - " +
                    "fresh and delicious." +
                    "Ingridients: salmon fillets 1 tsp. dried oregano, salt, black pepper" +
                    "extra-virgin olive oil, cloves garlic,cherry tomatoes, lemon, basil" +
                    "Parmesan ",
                    DishRating = "4.5",
                    DishGramm = 200,
                    DishCalories = 250,
                    DishPrepareTime = 10,
                    DishPrice = 45
                },
                new DishItem()
                {
                    DishID = 2,
                    CategoryId = 1,
                    DishImage = "fritters.jpg",
                    DishName = "Crab and corn fritters",
                    DishDescription = "Crab and corn fritters for your good evening" +
                    "Ingridients: extra virgin olive oil, unsalted butter" +
                    "large sweetcorn, chilli flakes, spring onions, crab meat, coriander," +
                    "flour, polenta, buttermilk, eggs, ",
                    DishRating = "4.3",
                    DishGramm = 150,
                    DishCalories = 200,
                    DishPrepareTime = 10,
                    DishPrice = 70
                },
                new DishItem()
                {
                    DishID = 3,
                    CategoryId = 1,
                    DishImage = "nuggets.jpg",
                    DishName = "Parmesan chicken nuggets with three dipping sauces",
                    DishDescription = "" +
                    "Ingridients: white bread, mayonnaise, sunflower oil" +
                    "basil pesto, wholegrain mustard, sweet chilli sauce, parmesan, chicken breast, coriander," +
                    "flour, polenta, buttermilk, eggs",
                    DishRating = "4.1",
                    DishGramm = 150,
                    DishCalories = 270,
                    DishPrepareTime = 15,
                    DishPrice = 55
                },

                new DishItem()
                {
                    DishID = 4,
                    CategoryId = 2,
                    DishImage = "greeksalad.jpg",
                    DishName = "Greek Salad",
                    DishDescription = "" +
                    "Ingridients: grape tomatoes - or cherry tomatoes,red onion" +
                    "cucumber, green pepper, Kalamata olives, feta cheese, romaine lettuce",
                    DishRating = "4.9",
                    DishGramm = 250,
                    DishCalories = 220,
                    DishPrepareTime = 15,
                    DishPrice = 60
                },
                new DishItem()
                {
                    DishID = 5,
                    CategoryId = 2,
                    DishImage = "pastasalad.jpg",
                    DishName = "Italian pasta salad",
                    DishDescription = "" +
                    "Ingridients: pasta, salami, grape tomatoes, bell peppers, red onion" +
                    "black olives, mozzarella balls",
                    DishRating = "4.1",
                    DishGramm = 250,
                    DishCalories = 330,
                    DishPrepareTime = 15,
                    DishPrice = 70
                },

                new DishItem()
                {
                    DishID = 6,
                    CategoryId = 3,
                    DishImage = "carrotsoup.png",
                    DishName = "Spiced carrot & lentil soup",
                    DishDescription = "" +
                    "Ingridients: cumin seeds, chilli flakes, olive oil, carrots, split red lentils, " +
                    "vegetable stock, milk",
                    DishRating = "4.0",
                    DishGramm = 350,
                    DishCalories = 330,
                    DishPrepareTime = 20,
                    DishPrice = 75
                },
                new DishItem()
                {
                    DishID = 7,
                    CategoryId = 3,
                    DishImage = "pumpkinsoup.jpg",
                    DishName = "Pumpkin soup",
                    DishDescription = "" +
                    "Ingridients: olive oil, onions, pumpkin, vegetable stock, double cream, " +
                    "wholemeal seeded bread, pumpkin seeds, arahis",
                    DishRating = "5.0",
                    DishGramm = 350,
                    DishCalories = 200,
                    DishPrepareTime = 20,
                    DishPrice = 80
                },

                new DishItem()
                {
                    DishID = 8,
                    CategoryId = 4,
                    DishImage = "roastchicken.jpg",
                    DishName = "Roast chicken fillets",
                    DishDescription = "" +
                    "Ingridients: chicken, fresh thyme leaves, Dijon mustard, " +
                    "garlic, minced, lemon, olive oil, onions",
                    DishRating = "4.7",
                    DishGramm = 300,
                    DishCalories = 260,
                    DishPrepareTime = 20,
                    DishPrice = 85
                },
                new DishItem()
                {
                    DishID = 9,
                    CategoryId = 4,
                    DishImage = "beefwine.jpg",
                    DishName = "Beef Stew in Red Wine",
                    DishDescription = "" +
                    "Ingridients: canola oil, sirloin roast, brisket, " +
                    "flour, onions, dry red wine, tomato paste, " +
                    "chicken broth, bay leaves, fresh thyme, red potatoes, carrots, peas, parsley",
                    DishRating = "4.7",
                    DishGramm = 270,
                    DishCalories = 310,
                    DishPrepareTime = 30,
                    DishPrice = 105
                },

                new DishItem()
                {
                    DishID = 10,
                    CategoryId = 5,
                    DishImage = "potatowedges.jpg",
                    DishName = "Crispy Potato Wedges",
                    DishDescription = "" +
                    "Ingridients: russet potatoes, olive oil, parmesan",
                    DishRating = "4.4",
                    DishGramm = 150,
                    DishCalories = 350,
                    DishPrepareTime = 10,
                    DishPrice = 45
                },
                new DishItem()
                {
                    DishID = 11,
                    CategoryId = 5,
                    DishImage = "creamypotato.png",
                    DishName = "Creamy Cheesy Potatoes",
                    DishDescription = "" +
                    "Ingridients: potatoes, sour cream, cream of chicken soup, onion, cheese," +
                    "corn flakes, butter",
                    DishRating = "4.0",
                    DishGramm = 150,
                    DishCalories = 370,
                    DishPrepareTime = 10,
                    DishPrice = 60
                },

                new DishItem()
                {
                    DishID = 12,
                    CategoryId = 6,
                    DishImage = "ricedessert.jpg",
                    DishName = "Rice Krispie Treats",
                    DishDescription = "" +
                    "Ingridients: rice cereal, marshmallows, butter, salt, vanilla",
                    DishRating = "4.0",
                    DishGramm = 170,
                    DishCalories = 330,
                    DishPrepareTime = 15,
                    DishPrice = 65
                },
                new DishItem()
                {
                    DishID = 13,
                    CategoryId = 6,
                    DishImage = "frostiedessert.jpg",
                    DishName = "Chocolate Cream Cheese Frosting",
                    DishDescription = "" +
                    "Ingridients: salt, vanilla, cocoa, sugar, cream cheese, butter",
                    DishRating = "4.0",
                    DishGramm = 170,
                    DishCalories = 270,
                    DishPrepareTime = 15,
                    DishPrice = 70
                },

                new DishItem()
                {
                    DishID = 14,
                    CategoryId = 7,
                    DishImage = "margarita.jpg",
                    DishName = "Margarita",
                    DishDescription = "" +
                    "Ingridients: tequilla, cointreau, lime",
                    DishRating = "5.0",
                    DishGramm = 200,
                    DishCalories = 150,
                    DishPrepareTime = 10,
                    DishPrice = 80
                },
                new DishItem()
                {
                    DishID = 15,
                    CategoryId = 7,
                    DishImage = "tomcollins.jpg",
                    DishName = "Tom Collins",
                    DishDescription = "" +
                    "Ingridients: gin, lemon juice, soda, syrop",
                    DishRating = "4.5",
                    DishGramm = 250,
                    DishCalories = 170,
                    DishPrepareTime = 10,
                    DishPrice = 85
                },

            };
        }

        public async Task AddDishItemAsync()
        {
            try
            {
                foreach (var dish in DishItems)
                {
                    await client.Child("DishItems").PostAsync(new DishItem()
                    {
                        DishID = dish.DishID,
                        CategoryId = dish.CategoryId,
                        DishImage = dish.DishImage,
                        DishName = dish.DishName,
                        DishDescription = dish.DishDescription,
                        DishRating = dish.DishRating,
                        DishGramm = dish.DishGramm,
                        DishCalories = dish.DishCalories,
                        DishPrepareTime = dish.DishPrepareTime,
                        DishPrice = dish.DishPrice,

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

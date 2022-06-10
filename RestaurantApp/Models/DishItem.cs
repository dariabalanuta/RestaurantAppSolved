using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Models
{
    public class DishItem
    {
        public int DishID { get; set; }
        public string DishImage { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public string DishRating { get; set; }
        public int DishGramm { get; set; }
        public float DishCalories { get; set; }
        public int DishPrepareTime { get; set; }
        public decimal DishPrice { get; set; }
        public int CategoryId { get; set; }

    }
}

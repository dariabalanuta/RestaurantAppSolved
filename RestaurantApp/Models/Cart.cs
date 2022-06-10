using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Models
{
    internal class Cart
    {
        public string UserName { get; set; }
        public string TableId { get; set; }
        public int CartId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Models
{
    internal class UserCartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string CartItemName { get; set; }
        public decimal CartItemPrice { get; set; }
        public int CartItemQuantity { get; set; }
        public decimal CartItemCost { get; set; }
        public int tableId { get; set; }

    }
}

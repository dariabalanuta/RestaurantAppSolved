using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Models
{
    [Table("CartItem")]
    public class CartItem
    {
        [AutoIncrement, PrimaryKey]
        public int CartItemId { get; set; }
        public int ProductId  { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity  { get; set; }
        public int tableId { get; set; }

    }
}

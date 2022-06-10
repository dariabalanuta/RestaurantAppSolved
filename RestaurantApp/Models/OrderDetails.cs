using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Models
{
    internal class OrderDetails
    {
        public int TableId { get; set; }
        public string OrderDetailId { get; set; }
        public string OrderId{ get; set; } 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Price { get; set; }

    }
}

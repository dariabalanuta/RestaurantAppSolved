using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Models
{
    internal class Order
    {
        public int TableId { get; set; }
        public string OrderId { get; set; }
        public string Username { get; set; }
        public decimal OrderTotalCost { get; set; }
    }
}

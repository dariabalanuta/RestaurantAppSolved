using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public bool IsBusy = false;


    }
}

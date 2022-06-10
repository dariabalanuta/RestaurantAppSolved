using RestaurantApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RestaurantApp.Helpers
{
    internal class CreateCartTable
    {
        public bool CreatTable()
        {
            try
            {
                var con = DependencyService.Get<ISQLite>().GetConnection();
                con.CreateTable<CartItem>();
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

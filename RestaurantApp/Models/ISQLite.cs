using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Models
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}

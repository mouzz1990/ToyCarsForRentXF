using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyCarsForRentXF.Models;
using Xamarin.Forms;

namespace ToyCarsForRentXF.DataBase
{
    public class ToyCarsRepository
    {
        SQLiteConnection database;

        public ToyCarsRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);

            database.CreateTable<ToyCar>();
        }

        public IEnumerable<ToyCar> GetItems()
        {
            return (from i in database.Table<ToyCar>() select i).ToList();
        }

        public ToyCar GetItem(int id)
        {
            return database.Get<ToyCar>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<ToyCar>(id);
        }

        public int SaveItem(ToyCar car)
        {
            if (car.CarId != 0)
            {
                database.Update(car);
                return car.CarId;
            }
            else
            {
                return database.Insert(car);
            }
        }
    }
}

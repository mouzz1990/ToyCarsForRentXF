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
    public class ReportRepository
    {
        SQLiteConnection database;

        public ReportRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);

            database.CreateTable<ReportClass>();
        }

        public IEnumerable<ReportClass> GetItems()
        {
            return (from i in database.Table<ReportClass>() select i).ToList();
        }

        public ReportClass GetItem(int id)
        {
            return database.Get<ReportClass>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<ReportClass>(id);
        }

        public int SaveItem(ReportClass report)
        {
            if (report.ReportId != 0)
            {
                database.Update(report);
                return report.ReportId;
            }
            else
            {
                return database.Insert(report);
            }
        }
    }
}

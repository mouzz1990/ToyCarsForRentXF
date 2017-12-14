using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToyCarsForRentXF.DataBase;
using Xamarin.Forms;

namespace ToyCarsForRentXF
{
    public partial class App : Application
    {
        public const string TOYCARDATABASE_NAME = "toycars.db";
        public static ToyCarsRepository toycardatabase;
        public static ToyCarsRepository ToyCarDatabase
        {
            get
            {
                if (toycardatabase == null)
                {
                    toycardatabase = new ToyCarsRepository(TOYCARDATABASE_NAME);
                }
                return toycardatabase;
            }
        }

        public const string REPORTDATABASE_NAME = "reports.db";
        public static ReportRepository reportdatabase;
        public static ReportRepository ReportDatabase
        {
            get
            {
                if (reportdatabase == null)
                {
                    reportdatabase = new ReportRepository(REPORTDATABASE_NAME);
                }
                return reportdatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ToyCarsForRentXF.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

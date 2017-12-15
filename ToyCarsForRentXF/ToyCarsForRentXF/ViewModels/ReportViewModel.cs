using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToyCarsForRentXF.Models;
using Xamarin.Forms;

namespace ToyCarsForRentXF.ViewModels
{
    public class ReportViewModel : INotifyPropertyChanged
    {
        INavigation Navigation;

        public ReportViewModel(INavigation navigation)
        {
            Navigation = navigation;

            StartDate = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
            EndDate = DateTime.Today;
        }

        #region Properties
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; OnPropertyChanged(); }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; OnPropertyChanged(); }
        }

        private List<ReportOutput> reportOuptup;
        public List<ReportOutput> ReportOutput
        {
            get { return reportOuptup; }
            set { reportOuptup = value; OnPropertyChanged(); }
        }
        #endregion

        #region Commands
        private ICommand reportCommand;
        public ICommand ReportCommand
        {
            get
            {
                return reportCommand ?? (reportCommand = new Command(() => 
                {
                    var tc = from report in App.ReportDatabase.GetItems()
                             join car in App.ToyCarDatabase.GetItems() on report.ToyCarId equals car.CarId
                             where report.RentDateTime >= StartDate && report.RentDateTime <= EndDate.AddDays(1)
                             select new { report, car };

                    ReportOutput = new List<Models.ReportOutput>();
                    double price = 0;

                    ReportOutput.Add(new Models.ReportOutput()
                    {
                        CarTitle = "Car Title",
                        Minutes = "Minutes",
                        Price = "Price",
                        RentDate = "Date"
                    }
                    );

                    foreach (var t in tc)
                    {
                        ReportOutput.Add(new Models.ReportOutput()
                        {
                            CarTitle = t.car.CarTitle,
                            Minutes = t.report.MinutesCount.ToString(),
                            Price = t.report.Price.ToString(),
                            RentDate = t.report.RentDateTime.ToString("dd.MM.yyyy HH:mm:ss")
                        });

                        price += t.report.Price;
                    }

                    ReportOutput.Add(new Models.ReportOutput() { RentDate = "", CarTitle = "", Minutes = "Sum:", Price = price.ToString() });

                    Debug.WriteLine("DEBUG: " + ReportOutput.Count);
                }));
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}

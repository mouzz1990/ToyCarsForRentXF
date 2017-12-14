using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToyCarsForRentXF.Models;
using Xamarin.Forms;

namespace ToyCarsForRentXF.ViewModels
{
    public class StartRentViewModel : INotifyPropertyChanged
    {
        INavigation Navigation;

        public StartRentViewModel(ToyCar car, INavigation navigation)
        {
            Navigation = navigation;
            ToyCarEntry = car;
            Minutes = 10;
            Price = 30;
        }

        private ToyCar toyCarEntry;
        public ToyCar ToyCarEntry
        {
            get { return toyCarEntry; }
            set { toyCarEntry = value; OnPropertyChanged(); }
        }

        private int minutes;
        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; OnPropertyChanged(); }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged(); }
        }

        private ICommand startCommand;
        public ICommand StartCommand
        {
            get
            {
                return startCommand ?? (startCommand = new Command(async () =>
                {
                    if (Minutes == 0 || Price < 0) return;

                    //Add report information to the database
                    ReportClass rc = new ReportClass()
                    {
                        MinutesCount = Minutes,
                        Price = Price,
                        ToyCarId = ToyCarEntry.CarId,
                        RentDateTime = DateTime.Now
                    };

                    App.ReportDatabase.SaveItem(rc);

                    //Set toy car properties
                    ToyCarEntry.State.IsFree = false;
                    ToyCarEntry.State.Minutes = Minutes;

                    //Start timer and timer callback function
                    Device.StartTimer(TimeSpan.FromMinutes(1),
                        () =>
                        {
                            ToyCarEntry.State.Minutes--;

                            if (ToyCarEntry.State.Minutes == 0)
                            {
                                ToyCarEntry.State.IsFree = true;
                                return false;
                            }

                            return true;
                        });

                    await Navigation.PopAsync();
                }));
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion
    }
}

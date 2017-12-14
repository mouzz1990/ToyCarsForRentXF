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
        public StartRentViewModel(ToyCar car)
        {
            ToyCarEntry = car;
            Minutes = 10;
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


        private ICommand startCommand;
        public ICommand StartCommand
        {
            get
            {
                return startCommand ?? (startCommand = new Command(() => 
                {
                    //Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(5), () => { return true; });
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

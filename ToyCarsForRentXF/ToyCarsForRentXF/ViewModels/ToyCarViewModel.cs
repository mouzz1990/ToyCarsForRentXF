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
    public class ToyCarViewModel : INotifyPropertyChanged
    {
        INavigation Navigation;

        public ToyCarViewModel(ToyCar selectedCar, INavigation navigation)
        {
            ToyCarEntire = selectedCar;
            Navigation = navigation;
        }

        private ToyCar toyCarEntire;
        public ToyCar ToyCarEntire
        {
            get { return toyCarEntire; }
            set { toyCarEntire = value; }
        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new Command(async () => 
                {
                    await Navigation.PopAsync();
                }
                ));
            }
        }

        private ICommand selectImageCommand;
        public ICommand SelectImageCommand
        {
            get
            {
                return selectImageCommand ?? (selectImageCommand = new Command(()=> 
                {
                    
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

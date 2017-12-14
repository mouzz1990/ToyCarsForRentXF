using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToyCarsForRentXF.Models;
using ToyCarsForRentXF.Views;
using Xamarin.Forms;

namespace ToyCarsForRentXF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        INavigation Navigation;
        Page Page;

        public MainViewModel(INavigation navigation, Page page)
        {
            Navigation = navigation;
            Page = page;
            
            ToyCars = new ObservableCollection<ToyCar>()
            {
                new ToyCar() { CarId = 1, CarTitle = "1", ImageName = "1.jpg" },
                new ToyCar() { CarId = 2, CarTitle = "2", ImageName = "2.jpg" },
                new ToyCar() { CarId = 3, CarTitle = "3", ImageName = "3.jpg" },
                new ToyCar() { CarId = 4, CarTitle = "4", ImageName = "4.jpg" },
                new ToyCar() { CarId = 5, CarTitle = "5", ImageName = "5.jpg" },
                new ToyCar() { CarId = 6, CarTitle = "6", ImageName = "6.jpg" },
            };
        }

        private ToyCar selectedCar;
        public ToyCar SelectedCar
        {
            get { return selectedCar; }
            set { selectedCar = value; OnPropertyChanged(); }
        }


        private ObservableCollection<ToyCar> toyCars;
        public ObservableCollection<ToyCar> ToyCars
        {
            get { return toyCars; }
            set { toyCars = value; OnPropertyChanged(); }
        }

        private ICommand toyCarClickCommand;
        public ICommand ToyCarClickCommand
        {
            get
            {
                return toyCarClickCommand ?? (toyCarClickCommand = new Command(async (obj) => 
                {
                    ToyCar car = obj as ToyCar;
                    //Open window to set time and start timer
                    StartRentPage srp = new StartRentPage(car);
                    await Navigation.PushAsync(srp);
                }));
            }
        }

        private ICommand editToyCarCommand;
        public ICommand EditToyCarCommand
        {
            get
            {
                return editToyCarCommand ?? (editToyCarCommand = new Command(async () => 
                {
                    if (SelectedCar == null) return;

                    ToyCarPage tcp = new ToyCarPage(SelectedCar);
                    await Navigation.PushAsync(tcp);
                }));
            }
        }

        private ICommand addToyCarCommand;
        public ICommand AddToyCarCommand
        {
            get
            {
                return addToyCarCommand ?? (addToyCarCommand = new Command(async () => 
                {
                    ToyCar tc = new ToyCar() {  CarTitle = "New Car" };
                    ToyCars.Add(tc);

                    ToyCarPage tcp = new ToyCarPage(tc);
                    await Navigation.PushAsync(tcp);
                }));
            }
        }

        private ICommand removeToyCarCommand;
        public ICommand RemoveToyCarCommand
        {
            get
            {
                return removeToyCarCommand ?? (removeToyCarCommand = new Command(async () => 
                {
                    if (SelectedCar == null) return;

                    var result = await Page.DisplayAlert(
                        $"Removing Toy Car",
                        $"Remove Toy Car: {SelectedCar.CarTitle}?",
                        "Remove",
                        "Cancel"
                        );

                    if (result)
                        ToyCars.Remove(SelectedCar);
                },
                () => { return true; }
                
                ));
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

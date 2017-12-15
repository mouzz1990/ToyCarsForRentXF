using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

            ToyCars = new ObservableCollection<ToyCar>(App.ToyCarDatabase.GetItems());
        }

        #region Properties
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
        #endregion

        #region Commands
        private ICommand toyCarClickCommand;
        public ICommand ToyCarClickCommand
        {
            get
            {
                return toyCarClickCommand ?? (toyCarClickCommand = new Command(async (obj) => 
                {
                    ToyCar car = obj as ToyCar;
                    //Open window to set time, price and start timer
                    StartRentPage srp = new StartRentPage(car);
                    await Navigation.PushAsync(srp);
                }
                ));
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
                    App.ToyCarDatabase.SaveItem(tc);
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
                    {
                        App.ToyCarDatabase.DeleteItem(SelectedCar.CarId);
                        ToyCars.Remove(SelectedCar);
                    }
                },
                () => { return true; }
                
                ));
            }
        }

        private ICommand reportCommand;
        public ICommand ReportCommand
        {
            get
            {
                return reportCommand ?? (reportCommand = new Command(async () => 
                {
                    ReportPage rp = new ReportPage();
                    await Navigation.PushAsync(rp);
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

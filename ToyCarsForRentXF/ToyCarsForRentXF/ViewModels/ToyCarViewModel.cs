using PCLStorage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ToyCarsForRentXF.Models;
using ToyCarsForRentXF.Pictures;
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

        #region Properties
        private ToyCar toyCarEntire;
        public ToyCar ToyCarEntire
        {
            get { return toyCarEntire; }
            set { toyCarEntire = value; }
        }
        #endregion

        #region Commands
        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new Command(async () => 
                {
                    App.ToyCarDatabase.SaveItem(ToyCarEntire);

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
                return selectImageCommand ?? (selectImageCommand = new Command(async ()=> 
                {
                    //Setup file name to toy car entry
                    ToyCarEntire.ImageName = ToyCarEntire.CarId + ".jpg";

                    //Open Gallery and copy selected file from gallery to the application local folder
                    using (Stream stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync())
                    {
                        IFile file = await FileSystem.Current.LocalStorage.CreateFileAsync(ToyCarEntire.CarId + ".jpg", CreationCollisionOption.ReplaceExisting);
                        using (Stream sw = await file.OpenAsync(FileAccess.ReadAndWrite))
                        {
                            stream.CopyTo(sw);
                        }
                    }

                    //For updating View
                    OnPropertyChanged("ToyCarEntire");
                    ToyCarEntire.OnPropertyChanged("ImageName");
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

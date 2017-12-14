using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToyCarsForRentXF.Models
{
    public class ToyCar : INotifyPropertyChanged
    {
        private int carId;
        [PrimaryKey, AutoIncrement]
        public int CarId
        {
            get { return carId; }
            set { carId = value; OnPropertyChanged(); }
        }

        private string carTitle;
        public string CarTitle
        {
            get { return carTitle; }
            set { carTitle = value; OnPropertyChanged(); }
        }

        private string imageName;
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; OnPropertyChanged(); }
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

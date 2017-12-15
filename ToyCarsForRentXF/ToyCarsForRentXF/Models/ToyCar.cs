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
    [Table("ToyCars")]
    public class ToyCar : INotifyPropertyChanged
    {
        public ToyCar()
        {
            State = new ToyCarState();
        }

        private int carId;
        [PrimaryKey, AutoIncrement, Column("id")]
        public int CarId
        {
            get { return carId; }
            set { carId = value; OnPropertyChanged(); }
        }

        private string carTitle;
        [Column("Title")]
        public string CarTitle
        {
            get { return carTitle; }
            set { carTitle = value; OnPropertyChanged(); }
        }

        private string imageName;
        [Column("ImageName")]
        public string ImageName
        {
            get { return imageName; }
            set { imageName = value; OnPropertyChanged(); }
        }

        private ToyCarState state;
        [Ignore]
        public ToyCarState State
        {
            get { return state; }
            set { state = value; OnPropertyChanged(); }
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

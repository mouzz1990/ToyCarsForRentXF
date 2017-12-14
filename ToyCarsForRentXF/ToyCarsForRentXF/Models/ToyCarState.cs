using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToyCarsForRentXF.Models
{
    public class ToyCarState : INotifyPropertyChanged
    {
        public ToyCarState()
        {
            IsFree = true;
        }

        private bool isFree;
        public bool IsFree
        {
            get { return isFree; }
            set { isFree = value; OnPropertyChanged(); }
        }

        private int minutes;
        public int Minutes
        {
            get { return minutes; }
            set { minutes = value; OnPropertyChanged(); }
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

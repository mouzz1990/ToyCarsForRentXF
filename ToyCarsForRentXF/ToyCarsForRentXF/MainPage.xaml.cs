using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyCarsForRentXF.ViewModels;
using Xamarin.Forms;

namespace ToyCarsForRentXF
{
    public partial class MainPage : ContentPage
    {
        MainViewModel mvm;

        public MainPage()
        {
            InitializeComponent();

            mvm = new MainViewModel(Navigation, this);
            
            BindingContext = mvm;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyCarsForRentXF.Models;
using ToyCarsForRentXF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToyCarsForRentXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToyCarPage : ContentPage
    {
        ToyCarViewModel tcvm;

        public ToyCarPage(ToyCar selectedCar)
        {
            InitializeComponent();
            
            tcvm = new ToyCarViewModel(selectedCar, Navigation);
            BindingContext = tcvm;
            
        }
    }
}
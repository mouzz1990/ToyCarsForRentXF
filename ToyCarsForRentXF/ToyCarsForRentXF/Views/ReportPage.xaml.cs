using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyCarsForRentXF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToyCarsForRentXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {
        ReportViewModel rvm;

        public ReportPage()
        {
            InitializeComponent();

            rvm = new ReportViewModel(Navigation);

            BindingContext = rvm;
        }
    }
}
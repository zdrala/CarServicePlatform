using CarService.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarService.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicesPage : ContentPage
    {
        public Data.Model.CarService csModel;

        private ServicesViewModel model = null;
        public ServicesPage(Data.Model.CarService cs)
        {
            InitializeComponent();
            BindingContext = model = new ServicesViewModel()
            { CarService = cs
            };

            csModel = cs;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Load(csModel);
        }
    }
}
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
    public partial class CarServicesPage : ContentPage
    {
        private CarServicesViewModel model = null;
        public CarServicesPage()
        {
            InitializeComponent();
            Title = "Prikaz auto servisa";
            BindingContext = model = new CarServicesViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Load();
        }
        private async void CarServiceSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Data.Model.CarService;

            await Navigation.PushAsync(new CarServiceDetailPage(item));
        }
    }
}
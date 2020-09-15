using CarService.Data.Model;
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
    public partial class CarServiceDetailPage : ContentPage
    {
        private CarServiceDetailViewModel model = null;

        public Data.Model.CarService csModel;
        public CarServiceDetailPage(Data.Model.CarService cs)
        {
            InitializeComponent();
            BindingContext = model = new CarServiceDetailViewModel() {
                CarService = cs
            };

            csModel = cs;
           
        }
        protected  override void OnAppearing()
        {
            base.OnAppearing();
             model.LoadInit(csModel);
        }

        private async void Clicked_LoadServices(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServicesPage(csModel));
        }

        private async void Clicked_CreateRequest(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateRequestPage(csModel));
        }

        private async void Clicked_MakeQuestion(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommunicationPage(csModel));
        }
    }
}
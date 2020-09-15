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
    public partial class RequestedServicesPage : ContentPage
    {
        private RequestedServicesViewModel model;
        public RequestedServicesPage(Data.Model.Schedule item)
        {
            InitializeComponent();
            BindingContext = model = new RequestedServicesViewModel()
            {
                scheduleModel = item
            };

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Load();
        }
    }
}
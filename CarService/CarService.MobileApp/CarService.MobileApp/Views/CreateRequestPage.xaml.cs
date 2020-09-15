using CarService.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarService.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateRequestPage : ContentPage
    {
        public Data.Model.CarService csModel;
        private CreateRequestViewModel model = null;


        public CreateRequestPage(Data.Model.CarService cs)
        {
            InitializeComponent();
            BindingContext = model = new CreateRequestViewModel();
            

            csModel = cs;
 
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.LoadInit(csModel);
        }

        private async void SendRequest_Clicked(object sender, EventArgs e)
        {
            if (model.GetSelectedServicesList_Count() == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Greška!", "Morate odabrati minimalno jednu uslugu!", "OK");
                return;
            }
                await model.SendRequest();
            await Navigation.PopAsync();
        }
    }
}
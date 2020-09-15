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
    public partial class ScheduleDetailsPage : ContentPage
    {
        public Data.Model.Schedule scheduleModel;

        private ScheduleDetailsVM model = null;
        public ScheduleDetailsPage(Data.Model.Schedule item)
        {
            InitializeComponent();
            scheduleModel = item;
            BindingContext = model = new ScheduleDetailsVM()
            { ScheduleModel = item
            };
        }
        protected async  override void OnAppearing()
        {
            base.OnAppearing();
           await model.Load();
        }

        private async void LoadRequestedServices(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RequestedServicesPage(scheduleModel));
        }

        private async void SelectOffersParts(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectOfferItemsPage(scheduleModel));
        }

        private async void ShowSelectedParts(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectedOfferPartsPage(scheduleModel));
        }

        private async void Rate_Positive(object sender, EventArgs e)
        {
            await model.RatePositive();
            await Application.Current.MainPage.DisplayAlert("Uspješno", "Ocijenili ste obavljene usluge na ovom terminu POZITIVNO", "OK");
            await model.Load();
        }
        private async void Rate_Negative(object sender, EventArgs e)
        {
            await model.RateNegative();
            await Application.Current.MainPage.DisplayAlert("Uspješno", "Ocijenili ste obavljene usluge na ovom terminu NEGATIVNO", "OK");
            await model.Load();
        }

        private async void PayTicket(object sender, EventArgs e)
        {
           await model.Load();
            if(model.ScheduleVM.isPaid)
            {
                await Application.Current.MainPage.DisplayAlert("Upozorenje", "Ovaj termin ste već platili!", "OK");
                return;
            }
            await Navigation.PushAsync(new PaymentGatwayPage(scheduleModel));
        }

        private async void TicketDetails(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TicketDetailsPage(scheduleModel));
        }
    }
}
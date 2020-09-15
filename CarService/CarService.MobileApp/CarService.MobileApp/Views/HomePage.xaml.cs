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
    public partial class HomePage : ContentPage
    {
        private HomeViewModel model = null;
     
        public HomePage()
        {
            InitializeComponent();
            imgDisp.Source = "logo_eMechanic.png";
            Title = "eMechanic                 " + APIService.Username;

            BindingContext = model = new HomeViewModel();

        }
        private async void LoadCarServices(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarServicesPage());
        }

        private async void LoadSchedules(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new YourSchedulesPage());
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
          await model.Load();
            
           if(model.getBool_isSentOffer())
            {
                await Application.Current.MainPage.DisplayAlert("Vaš aktivni termin.", "Administrator vam je poslao ponudu sa dijelovima. Odaberite dijelove sa ponude.", "OK");
            }
        }

    }
}
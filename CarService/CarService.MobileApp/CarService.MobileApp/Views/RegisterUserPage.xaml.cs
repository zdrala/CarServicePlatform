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
    public partial class RegisterUserPage : ContentPage
    {
        private RegisterViewModel model = null;
        public RegisterUserPage()
        {
            InitializeComponent();
            BindingContext= model = new RegisterViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadInit();
        }
        private async void Button_Clicked_Canceled(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}
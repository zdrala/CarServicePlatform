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
    public partial class CommunicationPage : ContentPage
    {
        private CommunicationViewModel model = null;
        public CommunicationPage(Data.Model.CarService cs)
        {
            InitializeComponent();

            BindingContext = model = new CommunicationViewModel()
            {
                modelCS=cs 
            };
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Load();
        }

        private async void SendQuestion(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(model.QuestionContent))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Morate unijeti tekst pitanja!", "OK");
                return;
            }
            await model.SendQuestion();
            var modelC = model.modelCommunication;

         
            if(modelC!=null)
            {
                await Application.Current.MainPage.DisplayAlert("Pitanje poslano", "Uspješno ste postavili pitanje.", "OK");
            }

            model.Load();
        }
    }
}
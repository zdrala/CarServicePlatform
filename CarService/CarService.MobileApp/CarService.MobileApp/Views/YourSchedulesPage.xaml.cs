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
    public partial class YourSchedulesPage : ContentPage
    {

        private YourSchedulesViewModel model = null;
        public YourSchedulesPage()
        {
            InitializeComponent();
            BindingContext = model = new YourSchedulesViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Load();
        }

        private async void SelectSchedule(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Data.Model.Schedule;
            await Navigation.PushAsync(new ScheduleDetailsPage(item));
        }

        private async void SelectFinishedSchedule(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Data.Model.Schedule;
            await Navigation.PushAsync(new ScheduleDetailsPage(item));
        }
    }
}
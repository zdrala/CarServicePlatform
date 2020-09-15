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
    public partial class SelectedOfferPartsPage : ContentPage
    {
        private SelectedOfferPartsViewModel model;
        public Data.Model.Schedule scheduleModel;
        public SelectedOfferPartsPage(Data.Model.Schedule item)
        {
            InitializeComponent();

            BindingContext = model = new SelectedOfferPartsViewModel()
            {
                ScheduleModel = item
            };
            scheduleModel = item;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Load();
        }
    }
}
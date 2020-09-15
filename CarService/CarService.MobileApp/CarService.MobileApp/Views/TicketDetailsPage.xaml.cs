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
    public partial class TicketDetailsPage : ContentPage
    {
        private TicketDetailsViewModel model;
        public TicketDetailsPage(Data.Model.Schedule item)
        {
            InitializeComponent();
            BindingContext = model = new TicketDetailsViewModel()
            { ScheduleModel=item};
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Load();
        }
    }
}
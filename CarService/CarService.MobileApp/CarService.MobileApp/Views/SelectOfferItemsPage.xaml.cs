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
    public partial class SelectOfferItemsPage : ContentPage
    {
        private SelectOfferItemsViewModel model;
        public Data.Model.Schedule scheduleModel;


        public SelectOfferItemsPage(Data.Model.Schedule item)
        {
            InitializeComponent();
            BindingContext = model = new SelectOfferItemsViewModel()
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

        private void Load_SubCategoryParts(object sender, EventArgs e)
        {
            
            
            model.LoadParts();
        }

        private void PartSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Data.ViewModel.OfferItemsVM.Parts;
            model.addPart_ToSelectedPartsList(item);
        }

        private async void ChangeItems_ToSelected(object sender, EventArgs e)
        {

            if(model.Count_SelectedParts()==0)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Morate odabrati barem neke dijelove sa ponude da bi odabir dijelova bio uspješan!", "OK");
                return;
            }

            await model.ChangeToSelected();
                await Application.Current.MainPage.DisplayAlert("Uspješno", "Vaši odabiri sa ponude su uspješno poslani administratoru!", "OK");
                await Navigation.PopAsync();

  
        }
    }
}
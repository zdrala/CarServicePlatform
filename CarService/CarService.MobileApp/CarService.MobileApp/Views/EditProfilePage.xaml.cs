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
    public partial class EditProfilePage : ContentPage
    {
        EditProfileViewModel model = null;
        public EditProfilePage()
        {
            InitializeComponent();
            BindingContext = model = new EditProfileViewModel();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadInit();
        }

      
    }
}
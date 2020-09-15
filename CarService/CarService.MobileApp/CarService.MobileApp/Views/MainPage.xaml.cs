using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CarService.MobileApp.Models;
using System.Linq;

namespace CarService.MobileApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            //MenuPages.Add((int)MenuItemType.Home, new NavigationPage(new HomePage()));
            
        }

        public async Task NavigateFromMenu(int id)
        {
            if(id==0)
            {
                if (MenuPages.Count() > 0)
                {
                    MenuPages.Clear();
                    Navigation.NavigationStack.ToList().Clear();
                    MenuPages.Add(id, new NavigationPage(new HomePage()));
                }
            }

            if (id == 2) {
                await Navigation.PushModalAsync(new LoginPage());
               
            }

            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemType.Profil:
                        MenuPages.Add(id, new NavigationPage(new EditProfilePage()));
                        break;
                    case (int)MenuItemType.Odjava:
                        MenuPages.Add(id, new NavigationPage(new LoginPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await NavigateFromMenu(0);
        }
 
    }
}
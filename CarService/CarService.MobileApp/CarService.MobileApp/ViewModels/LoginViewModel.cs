using CarService.Data.Requests;
using CarService.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarService.MobileApp.ViewModels
{
    public class LoginViewModel:BaseViewModel
    {

        APIService _userService = new APIService("user");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
        }

        string _username = null;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = null;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
       

            try
            {
              
                if(string.IsNullOrWhiteSpace(Username)||string.IsNullOrWhiteSpace(Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Obavezno unesite korisničko ime i lozinku!", "Ok");
                    return;
                }


                APIService.Username = Username;
                APIService.Password = Password;
                var request = new UserSearchRequest()
                {
                    username = Username
                };
                var temp = await _userService.Get<List<Data.Model.Users>>(request);
                var obj = temp.First();
                if (obj.RoleID == 1)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Administrator nema pristup mobilnoj aplikaciji!", "Ok");
                    return;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("", "Prijava uspješna.", "Ok");
                }
                APIService.UserID = obj.UserID;
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(ex.Message, "Pogrešno korisničko ime ili lozinka", "Ok");
            }
        }
    }
}

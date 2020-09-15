using CarService.Data.Requests;
using CarService.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CarService.MobileApp.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        private readonly APIService _citiesService = new APIService("cities");

        private readonly APIService _modelsService = new APIService("carmodels");

        private readonly APIService _usersService = new APIService("userRegistering");

        public RegisterViewModel()
        {
            LoadCommand = new Command(async () => await LoadInit());
            RegisterCommand = new Command(async () => await Register());
        }
        public ObservableCollection<Data.Model.Cities> _citiesList { get; set; } = new ObservableCollection<Data.Model.Cities>();

        public ObservableCollection<Data.Model.CarModels> _modelsList { get; set; } = new ObservableCollection<Data.Model.CarModels>();

        public ICommand RegisterCommand { get; set; }

        public string FirstName { get; set; } = null;
        public string LastName { get; set; } = null;
        public DateTime DateOfBirth { get; set; } 
        public string Email { get; set; } = null;
        public string PhoneNumber { get; set; } = null;
        public string Username { get; set; } = null;
        public string Password { get; set; } = null;
        public string PasswordConfirmation { get; set; } = null;

        Data.Model.Cities _cityModel = null;



        Data.Model.CarModels _carModel = null;

        public Data.Model.Cities CityModel
        {
            get { return _cityModel; }
            set { SetProperty(ref _cityModel, value); }
        }

        public Data.Model.CarModels CarModel
        {
            get { return _carModel; }
            set { SetProperty(ref _carModel, value); }
        }
        public ICommand LoadCommand { get; set; }


        public async Task LoadInit()
        {
            var listCities = await _citiesService.Get<List<Data.Model.Cities>>(null);

            var listModels = await _modelsService.Get<List<Data.Model.CarModels>>(null);
            //_citiesList.Add(new Data.Model.Cities()
            //{
            //    CityID = 0,
            //    CityName = "Odaberi grad"
            //});
            foreach(var x in listCities)
            {
                _citiesList.Add(x);
            }
            foreach(var m in listModels)
            {
                _modelsList.Add(m);
            }
      
        }


        async Task Register()
        {
           
            if(CityModel==null)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Odaberi grad!", "Ok");
                return;
            }
            if (CarModel == null)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Odaberi model automobila!", "Ok");
                return;
            }

            if (Password != PasswordConfirmation)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Lozinke se ne podudaraju!", "Unesite ponovo");
                    return;
                }
                var listUsers = await _usersService.Get<List<Data.Model.Users>>(null);

            if (Username != null)
            {
                foreach (var item in listUsers)
                {
                    if (Username == item.Username)
                    {
                        await Application.Current.MainPage.DisplayAlert("Greška", "Korisničko ime već postoji.", "Pokušajte ponovo");
                        return;
                    }
                }
            }
                //Name
                if(string.IsNullOrWhiteSpace(FirstName)||FirstName.Length<3)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Ime je obavezno polje!Minimalna dužina mora biti 3 karaktera", "Ok");
                    return;
                 
                
                }

                if (char.IsLower(FirstName[0]))
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Prvo slovo imena mora biti veliko!", "Ok");
                    return;
                }
                bool containsInt = FirstName.Any(char.IsDigit);
                if (containsInt)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Brojevi u imenu nisu dozovljeni!", "Ok");
                    return;
                }

            //Last name
            if (string.IsNullOrWhiteSpace(LastName) || LastName.Length < 3)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Prezime je obavezno polje!Minimalna dužina mora biti 3 karaktera", "Ok");
                return;


            }

            if (char.IsLower(LastName[0]))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Prvo slovo prezimena mora biti veliko!", "Ok");
                return;
            }
            bool containsInta = LastName.Any(char.IsDigit);
            if (containsInta)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Brojevi u prezimenu nisu dozovljeni!", "Ok");
                return;
            }
            //Email

            if(string.IsNullOrWhiteSpace(Email))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Email je obavezno polje!", "Ok");
                return;
            }

            if (!Regex.IsMatch(Email, @"([a-z]+)([\\.]?)([a-z]*)([@])(yahoo|outlook|gmail|hotmail|fit|edu.fit)(.ba|.com|.org)"))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Email mora biti u formatu: nešto@(gmail,hotmail,fit,edu.fit,outlook,yahoo).(ba,com,org)", "Ok");
                return;
            }

            //PhoneNumber
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Broj telefona je obavezno polje!", "Ok");
                return;
            }

            if (!Regex.IsMatch(PhoneNumber, @"(06[0-9])([/])([0-9]){3}([-])([0-9]){3}$"))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Broj telefona mora biti u formatu: 06X/XXX-XXX", "Ok");
                return;
            }

            //Username
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Korisničko ime je obavezno polje!Minimalna dužina mora biti 3 karaktera", "Ok");
                return;
            }

            if(string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Unesi lozinku!", "Ok");
                return;
            }
            if (string.IsNullOrWhiteSpace(PasswordConfirmation))
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Unesi potvrdu lozinke!", "Ok");
                return;
            }






            var request = new UserInsertUpdateRequest()
            {
                FirstName=FirstName,
                LastName=LastName,
                DateOfBirth=DateOfBirth,
                Email=Email,
                PhoneNumber=PhoneNumber,
                Username=Username,
                Password=Password,
                PasswordConfirmation=PasswordConfirmation,
                CityID=CityModel.CityID,
                CarBrandID=CarModel.CarBrandID,
                CarModelID=CarModel.CarModelID,
                RoleID=2
            };


            var modelUser = _usersService.Insert<Data.Model.Users>(request);




            if(modelUser!=null)
            {
                await Application.Current.MainPage.DisplayAlert("Uspješno ste napravili profil.", "Sada se prijavite.", "Ok");
                await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
            }








        }
    }
}

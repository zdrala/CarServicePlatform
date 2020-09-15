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
    public class EditProfileViewModel:BaseViewModel
    {
        private readonly APIService _citiesService = new APIService("cities");

        private readonly APIService _modelsService = new APIService("carmodels");
        private readonly APIService _usersService = new APIService("user");
        public EditProfileViewModel()
        {
            LoadCommand = new Command(async () => await LoadInit());
            SaveChangesCommand = new Command(async () => await SaveChanges());
            Title = "Profil";
        }

        public ObservableCollection<Data.Model.Cities> _citiesList { get; set; } = new ObservableCollection<Data.Model.Cities>();

        public ObservableCollection<Data.Model.CarModels> _modelsList { get; set; } = new ObservableCollection<Data.Model.CarModels>();
        public ICommand LoadCommand { get; set; }
        public ICommand SaveChangesCommand { get; set; }


        private string _carString = string.Empty;

        public string CarString
        {
            get { return _carString; }
            set { SetProperty(ref _carString, value); }
        }
        private string _cityString = string.Empty;
        
        public string CityString
        {
            get { return _cityString; }
            set { SetProperty(ref _cityString, value); }
        }
        private string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }

        private DateTime _dateofBirth;
        public DateTime DateOfBirth
        {
            get { return _dateofBirth; }
            set { SetProperty(ref _dateofBirth, value); }
        }
        private string _phone = string.Empty;
        public string PhoneNumber
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        private string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _newpassword = string.Empty;
        public string NewPassword
        {
            get { return _newpassword; }
            set { SetProperty(ref _newpassword, value); }
        }

        private string _newpasswordconfirm = string.Empty;
        public string NewPasswordConfirmation
        {
            get { return _newpasswordconfirm; }
            set { SetProperty(ref _newpasswordconfirm, value); }
        }

       

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
        public async Task LoadInit()
        {

            var userModel = await _usersService.GetById<Data.Model.Users>(APIService.UserID);

            var modelCity = await _citiesService.GetById<Data.Model.Cities>(userModel.CityID);
            if (modelCity != null)
            {
                CityModel = new Data.Model.Cities() {
                    CityID=modelCity.CityID,
                CityName=modelCity.CityName
                };
                CityString = modelCity.CityName;
            }
            var modelCar = await _modelsService.GetById<Data.Model.CarModels>(userModel.CarModelID);

            if (modelCar != null)
            {
                CarModel = new Data.Model.CarModels()
                {
                    CarModelID=modelCar.CarModelID,
                    CarModelName=modelCar.CarModelName,
                    CarBrandID=modelCar.CarBrandID
                };
                CarString = modelCar.CarModelName;
            }

            var listCities = await _citiesService.Get<List<Data.Model.Cities>>(null);

            var listModels = await _modelsService.Get<List<Data.Model.CarModels>>(null);
            //_citiesList.Add(new Data.Model.Cities()
            //{
            //    CityID = 0,
            //    CityName = "Odaberi grad"
            //});
            _citiesList.Clear();
            foreach (var x in listCities)
            {
                
                    _citiesList.Add(x);
                
            }
            _modelsList.Clear();
            foreach (var m in listModels)
            {
              
                    _modelsList.Add(m);
                
            }

         

            FirstName = userModel.FirstName;
            LastName = userModel.LastName;
            DateOfBirth = userModel.DateOfBirth.GetValueOrDefault();
            Email = userModel.Email;
            PhoneNumber = userModel.PhoneNumber;
            Username = userModel.Username;

        


        }
        public async Task SaveChanges()
        {
      

            if (NewPassword != NewPasswordConfirmation)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", "Nove Lozinke se ne podudaraju!", "Unesite ponovo");
                return;
            }
            var listUsers = await _usersService.Get<List<Data.Model.Users>>(null);

            if (Username != null)
            {
                foreach (var item in listUsers)
                {
                    if (Username == item.Username&&item.UserID!=APIService.UserID)
                    {
                        await Application.Current.MainPage.DisplayAlert("Greška", "Korisničko ime već postoji.", "Pokušajte ponovo");
                        return;
                    }
                }
            }
            //Name
            if (string.IsNullOrWhiteSpace(FirstName) || FirstName.Length < 3)
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

            if (string.IsNullOrWhiteSpace(Email))
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


            var request = new UserInsertUpdateRequest()
            {
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Username = Username,
                //CityID = CityModel.CityID,
                //CarBrandID = CarModel.CarBrandID,
                //CarModelID = CarModel.CarModelID,
                RoleID = 2
            };
            if (CityModel != null)
                request.CityID = CityModel.CityID;

            if (CarModel != null)
            {
                request.CarModelID = CarModel.CarModelID;
                request.CarBrandID = CarModel.CarBrandID;
            }

            if(!string.IsNullOrEmpty(NewPassword))
            {
                request.Password = NewPassword;
                request.PasswordConfirmation = NewPasswordConfirmation;
            }


            var modelUserUpdated = await _usersService.Update<Data.Model.Users>(APIService.UserID, request);


            if(modelUserUpdated!=null)
            {
                await Application.Current.MainPage.DisplayAlert("Uspješno", "Izmijene uspješno napravljenje. Prijavite se ponovo da bi se podaci osvježili.", "OK");
                await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
            }
        }
    }
}

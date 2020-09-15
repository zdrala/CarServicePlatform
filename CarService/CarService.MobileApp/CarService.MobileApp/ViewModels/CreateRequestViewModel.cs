using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using CarService.MobileApp.Views;
namespace CarService.MobileApp.ViewModels
{
    public class CreateRequestViewModel:BaseViewModel
    {
        //public CreateRequestViewModel(ObservableCollection<Data.Model.Services> ___SelectedServicesList)
        //{
        //    if(___SelectedServicesList!=null)
        //    SelectedServicesList = ___SelectedServicesList;
        //}
        public ICommand AddServiceCommand { get; set; }
        public ICommand SendRequestCommand { get; set; }
        public CreateRequestViewModel()
        {
            AddServiceCommand = new Command(async () => await AddService());
            SendRequestCommand = new Command(async () => await SendRequest());
        }
        private readonly APIService _serviceService = new APIService("services");
        private readonly APIService _requestService = new APIService("request");
        private readonly APIService _requestByClientService = new APIService("RequestByClient");
        private readonly APIService _userService = new APIService("user");


        private readonly APIService _scheduleService = new APIService("schedule");
        public ObservableCollection<Data.Model.Services> servicesList { get; set; } = new ObservableCollection<Data.Model.Services>();
        public ObservableCollection<Data.Model.Services> SelectedServicesList { get; set; } = new ObservableCollection<Data.Model.Services>();
        public Data.Model.CarService modelCS { get; set; }
        private string _street = string.Empty;
        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }

        private string _csn = string.Empty;
        public string CarServiceName
        {
            get { return _csn; }
            set { SetProperty(ref _csn, value); }
        }

        Data.Model.Services _serviceModel = null;
        public Data.Model.Services ServiceModel
        {
            get { return _serviceModel; }
            set { SetProperty(ref _serviceModel, value); }
        }


        public async void LoadInit(Data.Model.CarService model)
        {
            modelCS = model;
          
            var req = new ServicesSearchRequest()
            {
                CarServiceID = model.CarServiceID
            };
            CarServiceName = model.CarServiceName;
            Street = model.Street;
            var list = await _serviceService.Get<List<Data.Model.Services>>(req);

            servicesList.Clear();
            foreach (var x in list)
            {
                servicesList.Add(x);
            }

        }
        public async Task AddService()
        {
            if (ServiceModel == null)
            {
                await Application.Current.MainPage.DisplayAlert("Greška!", "Niste odabrali uslugu!", "Odaberite ponovo!");
                return;
            }

            foreach (var x in SelectedServicesList)
            {
                if (x.ServiceID == ServiceModel.ServiceID)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška!", "Usluga se već nalazi na listi odabranih!", "Odaberite novu.");
                    return;
                }
            }

            SelectedServicesList.Add(ServiceModel);

        }
        public async Task SendRequest()
        {

            var requestsList = await _requestByClientService.Get<List<Data.ViewModel.RequestVM>>(null);

            if (requestsList.Count() > 0)
            {
                foreach(var x in requestsList)
                {
                    if(x.UserID==APIService.UserID)
                    {
                        await Application.Current.MainPage.DisplayAlert("Upozorenje", "Imate već jedan aktivan zahtjev za termin servisiranja u nekom od auto servisa. Da bi poslali zahtjev za servisranjem nekom od auto servisa, ne smijete imati trenutno aktivnih zahtjeva(zahtjev koji je na čekanju i nije obrađen).", "OK");
                        return;
                    }
                }
            }
            var userModel = await _userService.GetById<Data.Model.Users>(APIService.UserID);


            ScheduleRequest schReq = new ScheduleRequest()
            {
                userName = userModel.FirstName,
                userLastName = userModel.LastName
            };

            var schedulesList = await _scheduleService.Get<List<Data.Model.Schedule>>(schReq);

            if (schedulesList.Count() > 0)
            {
                foreach (var x in schedulesList)
                {
                    if(x.ScheduleStatusID==1)
                    {
                        await Application.Current.MainPage.DisplayAlert("Upozorenje", "Trenutno imate aktivan termin u auto servisu: "+x.CarServiceName+". Trenutni termin mora biti završen(okončan) da bi mogli poslati novi zahtjev za servisiranjem u ovaj ili neki drugi auto servis!", "OK");
                        return;
                    }
                }
            }
            var request = new RequestUpsert()
            {
                DateOfRequest = DateTime.Now,
                UserID=APIService.UserID,
                CarServiceID=modelCS.CarServiceID,
                RequestStatusID=1,
                
            };
            foreach(var x in SelectedServicesList)
            {
                request._selectedServicesList.Add(new Data.Model.Services()
                {
                    ServiceID=x.ServiceID
                });
            }

            var modelReq = await _requestService.Insert<Data.Model.Request>(request);
            if(modelReq!=null)
            {
                await Application.Current.MainPage.DisplayAlert("Obrada uspješna.", "Uspješno ste poslali zahtjev za termin servisiranja.", "OK");
                return;
            }

        }
        public int GetSelectedServicesList_Count()
        {
            return SelectedServicesList.Count();
        }
    }
}

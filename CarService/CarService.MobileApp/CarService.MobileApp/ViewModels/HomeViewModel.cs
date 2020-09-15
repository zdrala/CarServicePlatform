using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.MobileApp.ViewModels
{
    public class HomeViewModel:BaseViewModel
    {
        private readonly APIService _userSchedulesService = new APIService("schedule");

        private readonly APIService _userService = new APIService("user");
        public ObservableCollection<Data.Model.Schedule> userSchedulesList { get; set; } = new ObservableCollection<Data.Model.Schedule>();
        public ObservableCollection<Data.Model.Schedule> userActiveScheduleList { get; set; } = new ObservableCollection<Data.Model.Schedule>();

        public Data.ViewModel.OffersVM OfferVM { get; set; }

        private readonly APIService _scheduleService = new APIService("schedule");

        private readonly APIService _offerService = new APIService("offers");
        public Data.ViewModel.ScheduleVM ScheduleVM { get; set; }
        public Data.Model.Schedule ActiveSchedule { get; set; }
        public bool sendMessage { get; set; } = false;
        public HomeViewModel()
        {

        }

        public string LoggedUser
        {
            get
            {
                return APIService.Username;
            }
        }

        public bool getBool_isSentOffer()
        {
            return sendMessage;
        }
        public async Task Load()
        {
            var userModel = await _userService.GetById<Data.Model.Users>(APIService.UserID);

            if (userModel != null)
            {
                var request = new ScheduleRequest()
                {
                    userName = userModel.FirstName,
                    userLastName = userModel.LastName,
                    AdminSearch = false
                };
                var list = await _userSchedulesService.Get<List<Data.Model.Schedule>>(request);

                userSchedulesList.Clear();
                foreach (var x in list)
                {
                    userSchedulesList.Add(x);
                }
            }
            userActiveScheduleList.Clear();
            foreach (var s in userSchedulesList)
            {
                if (s.ScheduleStatusID == 1)
                {
                    userActiveScheduleList.Add(s);
                }
            }
            if(userActiveScheduleList.Count()>0)
            ActiveSchedule = userActiveScheduleList.First();


            if(ActiveSchedule!=null)
            {
                ScheduleVM = await _scheduleService.GetById<Data.ViewModel.ScheduleVM>(ActiveSchedule.ScheduleID);

                var listOffer = await _offerService.Get<List<Data.ViewModel.OffersVM>>(new OfferSearchRequest()
                {
                    ScheduleID = ScheduleVM.ScheduleID
                });

                if (listOffer.Count() > 0)
                    OfferVM = listOffer.First();


                if(ScheduleVM.offerCreated)
                {
                    sendMessage = true;
                }

                if(OfferVM!=null)
                {
                    if (OfferVM.partsSelected)
                    {
                        sendMessage = false;
                    }
                }

            }
 


        }
    }
}

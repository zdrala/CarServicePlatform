using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarService.MobileApp.ViewModels
{
    public class YourSchedulesViewModel:BaseViewModel
    {

        private readonly APIService _userSchedulesService = new APIService("schedule");

        private readonly APIService _userService = new APIService("user");
        public ObservableCollection<Data.Model.Schedule> userSchedulesList { get; set; } = new ObservableCollection<Data.Model.Schedule>();

        public ObservableCollection<Data.Model.Schedule> userActiveScheduleList { get; set; } = new ObservableCollection<Data.Model.Schedule>();
        public ObservableCollection<Data.Model.Schedule> userFinishedSchedulesList { get; set; } = new ObservableCollection<Data.Model.Schedule>();
        public YourSchedulesViewModel()
        {
            //InitCommand = new Command(async () => await Load());
        }
        public ICommand InitCommand { get; set; }
        public async Task Load()
        {
            var userModel = await _userService.GetById<Data.Model.Users>(APIService.UserID);

            if(userModel!=null)
            {
                var request = new ScheduleRequest()
                {
                    userName = userModel.FirstName,
                    userLastName = userModel.LastName,
                    AdminSearch=false
                };
                var list = await _userSchedulesService.Get<List<Data.Model.Schedule>>(request);

                userSchedulesList.Clear();
                foreach(var x in list)
                {
                    userSchedulesList.Add(x);
                }
            }
            userActiveScheduleList.Clear();
            userFinishedSchedulesList.Clear();
            foreach(var s in userSchedulesList)
            {
                if(s.ScheduleStatusID==1)
                {
                    userActiveScheduleList.Add(s);
                }
                else
                {
                    userFinishedSchedulesList.Add(s);
                }
            }

            //var _carServicesList = await _carServicesService.Get<List<Data.Model.CarService>>(new CarServiceSearchRequest()
            //{
            //    userID = 0
            //});
            //CarServicesList.Clear();
            //foreach (var cs in _carServicesList)
            //{
            //    CarServicesList.Add(cs);
            //}


        }
    }
}

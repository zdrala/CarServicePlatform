using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace CarService.MobileApp.ViewModels
{
   public class RequestedServicesViewModel:BaseViewModel
    {

        private readonly APIService _requestService = new APIService("request");

        private Data.Model.Schedule _s = null;
        public Data.Model.Schedule scheduleModel
        {
            get { return _s; }
            set { SetProperty(ref _s, value); }
        }
        private Data.Model.Request _r = null;
        public Data.Model.Request requestModel {
            get { return _r; }
            set { SetProperty(ref _r, value); }
        }


        public ObservableCollection<Service> requestedServices { get; set; } = new ObservableCollection<Service>();

            public class Service
        {
            public string ServiceName { get; set; }
        }
      
        public async Task Load()
        {

            requestModel = await _requestService.GetById<Data.Model.Request>(scheduleModel.RequestID);

            foreach(var x in requestModel.ListOfRequestedServices)
            {
                requestedServices.Add(new Service() { ServiceName=x});
            }
        }

    }
}

using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.MobileApp.ViewModels
{
    public class TicketDetailsViewModel:BaseViewModel
    {
        public Data.Model.Schedule ScheduleModel { get; set; }

        private readonly APIService _scheduleService = new APIService("schedule");
        private readonly APIService _requestClientService = new APIService("requestbyclient");
        private readonly APIService _offerItemsService = new APIService("offeritems");
        private readonly APIService _offerService = new APIService("offers");
        public Data.ViewModel.OffersVM OfferVM { get; set; }
        public Data.ViewModel.OfferItemsVM OfferItemsVM { get; set; }
        public Data.ViewModel.RequestVM RequestVM { get; set; }
        Data.ViewModel.ScheduleVM scheduleVM = new Data.ViewModel.ScheduleVM();

        public ObservableCollection<SelectedPart> _selectedParts { get; set; } = new ObservableCollection<SelectedPart>();

        public class SelectedPart
        {
            public int ItemID { get; set; }
            public int CarPartID { get; set; }
            public byte[] Photo { get; set; }
            public string CarPartName { get; set; }
            public double CarPartPrice { get; set; }
            public string Quality { get; set; }
            public string SubCategoryName { get; set; }
            public int QuantityNeeded { get; set; }
            public double inTotal { get; set; }
        }

        public ObservableCollection<Service> _servicesList { get; set; } = new ObservableCollection<Service>();
        public class Service
        {
            public string ServiceName { get; set; }
            public string ServicePrice { get; set; }
        }

        private string _tp = string.Empty;
        public string TotalPrice
        {
            get { return _tp; }
            set { SetProperty(ref _tp, value); }
        }
        public async Task Load()
        {
            scheduleVM = await _scheduleService.GetById<Data.ViewModel.ScheduleVM>(ScheduleModel.ScheduleID);


            TotalPrice = scheduleVM.totalPrice.ToString() + " KM";




            var listOffer = await _offerService.Get<List<Data.ViewModel.OffersVM>>(new OfferSearchRequest()
            {
                ScheduleID = scheduleVM.ScheduleID
            });

            if (listOffer.Count() > 0)
                OfferVM = listOffer.First();
            if (OfferVM != null)
            {
                if (OfferVM.partsSelected)
                {

                    OfferItemsVM = await _offerItemsService.GetById<Data.ViewModel.OfferItemsVM>(OfferVM.OfferID);
                }
            }
            RequestVM = await _requestClientService.GetById<Data.ViewModel.RequestVM>(scheduleVM.RequestID);

            foreach(var i in RequestVM.ListOfRequestedServices)
            {
                _servicesList.Add(new Service() { ServiceName=i.ServiceName,ServicePrice=i.ServicePrice.ToString()+" KM"});
            }
            if (OfferItemsVM != null)
            {
                if (OfferItemsVM.listOfParts.Count() > 0)
                {
                    foreach (var x in OfferItemsVM.listOfParts)
                    {
                        _selectedParts.Add(new SelectedPart()
                        {
                            Photo = x.Photo,
                            CarPartName = x.CarPartName,
                            Quality = x.Quality,
                            QuantityNeeded = x.QuantityNeeded,
                            inTotal = x.QuantityNeeded * x.CarPartPrice
                        });
                    }
                }
            }


        }

    }
}

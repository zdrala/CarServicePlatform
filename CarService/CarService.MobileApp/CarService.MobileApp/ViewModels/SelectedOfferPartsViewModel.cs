using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.MobileApp.ViewModels
{
    public class SelectedOfferPartsViewModel:BaseViewModel
    {
        private Data.Model.Schedule _s = null;
        public Data.Model.Schedule ScheduleModel
        {
            get { return _s; }
            set { SetProperty(ref _s, value); }
        }

        public Data.ViewModel.ScheduleVM ScheduleVM { get; set; }


        public Data.ViewModel.OffersVM OfferVM { get; set; }


        public Data.ViewModel.OfferItemsVM OfferItemsVM { get; set; }

        private readonly APIService _scheduleService = new APIService("schedule");

        private readonly APIService _offerService = new APIService("offers");


        private readonly APIService _offerItemsUpdateService = new APIService("offeritems");


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


        public async Task Load()
        {
            if (ScheduleModel.ScheduleID > 0)
                ScheduleVM = await _scheduleService.GetById<Data.ViewModel.ScheduleVM>(ScheduleModel.ScheduleID);

            var listOffer = await _offerService.Get<List<Data.ViewModel.OffersVM>>(new OfferSearchRequest()
            {
                ScheduleID = ScheduleVM.ScheduleID
            });

            if (listOffer.Count() > 0)
                OfferVM = listOffer.First();


            if (OfferVM != null)
            {
                OfferItemsVM = await _offerItemsUpdateService.GetById<Data.ViewModel.OfferItemsVM>(OfferVM.OfferID);

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

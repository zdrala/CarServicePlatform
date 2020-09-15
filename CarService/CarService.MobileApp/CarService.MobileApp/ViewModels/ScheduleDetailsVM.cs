using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.MobileApp.ViewModels
{
    public class ScheduleDetailsVM:BaseViewModel
    {
        public Data.Model.Schedule ScheduleModel { get; set; }

        private Data.ViewModel.ScheduleVM _svm = null;
        public Data.ViewModel.ScheduleVM ScheduleVM { get { return _svm; } set { SetProperty(ref _svm, value); } }

        private readonly APIService _offerItemsService = new APIService("offeritems");
        public Data.ViewModel.OfferItemsVM OfferItemsVM { get; set; }
        public Data.ViewModel.OffersVM OfferVM { get; set; }

        public Data.ViewModel.RequestVM RequestVM { get; set; }

        public Data.Model.Ratings RatingModel { get; set; }


        private readonly APIService _scheduleService = new APIService("schedule");

        private readonly APIService _offerService = new APIService("offers");

        private readonly APIService _requestService = new APIService("requestbyclient");
        private readonly APIService _ratingsService = new APIService("ratings");

        private readonly APIService _CarServiceService = new APIService("carservice");

        private readonly APIService _ticketService = new APIService("ticket");

        private string offerCreatedorLocked = string.Empty;
        public string offerCreated_OrLocked { 
            get { return offerCreatedorLocked; } 
            set {
                SetProperty(ref offerCreatedorLocked, value);
            } 
        }


        private bool _buttonForSelect = false;
        public bool buttonForSelect_isVisible 
        { 
            get { return _buttonForSelect; } 
            set {
                SetProperty(ref _buttonForSelect, value); 
            } 
        }

        private bool _buttonForCheck = false;
        public bool buttonForCheckSelectedParts_isVisible { 
            get { return _buttonForCheck; } 
            set { SetProperty(ref _buttonForCheck, value);
            } 
        }

        private double _cijena = 0;
        public double UkupnaCijena
        {
            get { return _cijena; }
            set
            {
                SetProperty(ref _cijena, value);
            }
        }

        private bool _showTotalPrice = false;
        public bool ShowTotalPrice
        {
            get { return _showTotalPrice; }
            set
            {
                SetProperty(ref _showTotalPrice, value);
            }
        }
        public ScheduleDetailsVM()
        {

        }


        private string ratingText = string.Empty;
        public string RatingText
        {
            get { return ratingText; }
            set
            {
                SetProperty(ref ratingText, value);
            }
        }

        private bool _showImageButtons_ForRating = false;
        public bool ShowImageButtons_ForRate
        {
            get { return _showImageButtons_ForRating; }
            set
            {
                SetProperty(ref _showImageButtons_ForRating, value);
            }
        }

        private bool _showRatedButtonImage_Positive = false;
        public bool ShowRatedButtonImagePositive
        {
            get { return _showRatedButtonImage_Positive; }
            set
            {
                SetProperty(ref _showRatedButtonImage_Positive, value);
            }
        }
        private bool _showRatedButtonImage_Negative = false;
        public bool ShowRatedButtonImageNegative
        {
            get { return _showRatedButtonImage_Negative; }
            set
            {
                SetProperty(ref _showRatedButtonImage_Negative, value);
            }
        }

        private bool _showStack_ForTicket = false;
        public bool ShowTicketStack
        {
            get { return _showStack_ForTicket; }
            set
            {
                SetProperty(ref _showStack_ForTicket, value);
            }
        }
        public async Task Load()
        {
            if (ScheduleModel.ScheduleID > 0)
            ScheduleVM = await _scheduleService.GetById<Data.ViewModel.ScheduleVM>(ScheduleModel.ScheduleID);


            var ticketList = await _ticketService.Get<List<Data.Model.Ticket>>(new TicketSearchRequest() { ScheduleID = ScheduleVM.ScheduleID });

            if (ticketList.Count() > 0)
            {
                var ticketModel = ticketList.First();
                if (ticketModel != null)
                {
                    ShowTicketStack = true;
                }

            }

            var listOffer=await _offerService.Get<List<Data.ViewModel.OffersVM>>(new OfferSearchRequest(){
                ScheduleID=ScheduleVM.ScheduleID
            });

            if(listOffer.Count()>0)
            OfferVM = listOffer.First();

            if (ScheduleVM.offerCreated)
            {
                offerCreated_OrLocked = "Dobili ste ponudu sa dijelovima.";
                buttonForSelect_isVisible = true;
                buttonForCheckSelectedParts_isVisible = false;
            }

            if (OfferVM != null)
            {
                if (OfferVM.partsSelected)
                {
                    offerCreated_OrLocked = "Odabrali ste dijelove, i ponuda je sada zaključana!";
                    buttonForSelect_isVisible = false;
                    buttonForCheckSelectedParts_isVisible = true;
                    OfferItemsVM = await _offerItemsService.GetById<Data.ViewModel.OfferItemsVM>(OfferVM.OfferID);
                }
            }
            RequestVM = await _requestService.GetById<Data.ViewModel.RequestVM>(ScheduleVM.RequestID);

            UkupnaCijena = 0;
            foreach(var x in RequestVM.ListOfRequestedServices)
            {
                UkupnaCijena += x.ServicePrice;
            }

            if(ScheduleVM.ScheduleStatusID==2)
            {
                ShowTotalPrice = true;
                if (OfferItemsVM != null)
                {
                    if (OfferItemsVM.listOfParts.Count() > 0)
                    {
                        foreach (var i in OfferItemsVM.listOfParts)
                        {
                            UkupnaCijena += i.CarPartPrice * i.QuantityNeeded;
                        }
                    }
                }


                var ratingList = await _ratingsService.Get<List<Data.Model.Ratings>>(new RatingsSearchRequest() { ScheduleID=ScheduleVM.ScheduleID});

                if (ratingList.Count() > 0)
                    RatingModel = ratingList.First();



                if(RatingModel==null)
                {
                    RatingText = "Ocijenite obavljene usluge na terminu pozitivno ili negativno.";
                    ShowImageButtons_ForRate = true;
                    
                }
                else
                {
                    if (RatingModel.isLiked)
                    {
                        RatingText = "Ocijenili ste pozitivno obavljenje usluge";
                        ShowRatedButtonImagePositive = true;
                    }
                    else
                    {
                        RatingText = "Ocijenili ste negativno obavljenje usluge";
                        ShowRatedButtonImageNegative = true;
                    }

                    ShowImageButtons_ForRate = false;
                
                }







            }
            
        }

        public async Task RatePositive()
        {
            var request = new RatingInsertRequest()
            {
                isLiked = true,
                ScheduleID = ScheduleVM.ScheduleID,
                UserID = APIService.UserID,
                CarServiceID = RequestVM.CarServiceID,
                isDisliked = false
            };

            var modelRating = await _ratingsService.Insert<Data.Model.Ratings>(request);

            var csModel = await _CarServiceService.GetById<Data.Model.CarService>(RequestVM.CarServiceID);


            var model=await _CarServiceService.Update<Data.Model.CarService>(RequestVM.CarServiceID,new CarServiceUpsertRequest() 
            {
                CarServiceName=csModel.CarServiceName,
                CityID=csModel.CityID,
                PhoneNumber=csModel.PhoneNumber,
                Street=csModel.Street,
                isLiked=true 
            });
            
        }
        public async Task RateNegative()
        {
            var request = new RatingInsertRequest()
            {
                isLiked = false,
                ScheduleID = ScheduleVM.ScheduleID,
                UserID = APIService.UserID,
                CarServiceID = RequestVM.CarServiceID,
                isDisliked = true
            };

            var modelRating = await _ratingsService.Insert<Data.Model.Ratings>(request);
            var csModel = await _CarServiceService.GetById<Data.Model.CarService>(RequestVM.CarServiceID);
            var model=await _CarServiceService.Update<Data.Model.CarService>(RequestVM.CarServiceID,new CarServiceUpsertRequest() 
            {
                CarServiceName = csModel.CarServiceName,
                CityID = csModel.CityID,
                PhoneNumber = csModel.PhoneNumber,
                Street = csModel.Street,
                isDisliked = true 
            });

        }

    }
    
}

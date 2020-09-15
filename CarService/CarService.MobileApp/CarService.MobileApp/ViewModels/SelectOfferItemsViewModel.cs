using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.MobileApp.ViewModels
{
    public class SelectOfferItemsViewModel : BaseViewModel
    {
        private Data.Model.Schedule _s = null;
        public Data.Model.Schedule ScheduleModel
        {
            get { return _s; }
            set { SetProperty(ref _s, value); }
        }

        private Data.ViewModel.ScheduleVM.ItemsSelected _c = null;
        public Data.ViewModel.ScheduleVM.ItemsSelected SelectedSubCategory
        {
            get { return _c; }
            set { SetProperty(ref _c, value); }
        }

        private Data.ViewModel.ScheduleVM.ItemsSelected _cc = null;
        public Data.ViewModel.ScheduleVM.ItemsSelected _SelectedSubCategory
        {
            get { return _cc; }
            set { SetProperty(ref _cc, value); }
        }

        public Data.ViewModel.ScheduleVM ScheduleVM { get; set; }


        public Data.ViewModel.OffersVM OfferVM { get; set; }


        public Data.ViewModel.OfferItemsVM OfferItemsVM { get; set; }

        private readonly APIService _scheduleService = new APIService("schedule");

        private readonly APIService _offerService = new APIService("offers");

        private readonly APIService _offerItemsService = new APIService("offeritemsbyclient");

        private readonly APIService _offerItemsUpdateService = new APIService("offeritems");



        public ObservableCollection<Data.ViewModel.ScheduleVM.ItemsSelected> selectedPartsSubCategories { get; set; } = new ObservableCollection<Data.ViewModel.ScheduleVM.ItemsSelected>();

        public ObservableCollection<Data.ViewModel.ScheduleVM.ItemsSelected> selectedPartsSubCategories_ForShow { get; set; } = new ObservableCollection<Data.ViewModel.ScheduleVM.ItemsSelected>();
        public ObservableCollection<Data.ViewModel.ScheduleVM.ItemsSelected> selectedPartsSubCategories_Hide { get; set; } = new ObservableCollection<Data.ViewModel.ScheduleVM.ItemsSelected>();

        public ObservableCollection<Data.ViewModel.OfferItemsVM.Parts> PartsForShow { get; set; } = new ObservableCollection<Data.ViewModel.OfferItemsVM.Parts>();


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

            foreach (var x in ScheduleVM.selectedSubCategories)
            {
                selectedPartsSubCategories.Add(x);
                selectedPartsSubCategories_ForShow.Add(x);
            }

            if (OfferVM != null)
            {
                OfferItemsVM = await _offerItemsService.GetById<Data.ViewModel.OfferItemsVM>(OfferVM.OfferID);

            }



        }
        public void LoadParts()
        {
            if (selectedPartsSubCategories_ForShow.Count() > 0)
            {
                _SelectedSubCategory = SelectedSubCategory;
                PartsForShow.Clear();
                foreach (var x in OfferItemsVM.listOfParts)
                {
                    if (x.SubCategoryName == _SelectedSubCategory.SubCategoryName)
                        PartsForShow.Add(x);
                }
                
            }
        }

        public void addPart_ToSelectedPartsList(Data.ViewModel.OfferItemsVM.Parts item)
        {
            _selectedParts.Add(new SelectedPart()
            {
                ItemID = item.ItemID,
                CarPartID = item.CarPartID,
                Photo = item.Photo,
                CarPartName = item.CarPartName,
                CarPartPrice = item.CarPartPrice,
                QuantityNeeded = item.QuantityNeeded,
                Quality = item.Quality,
                inTotal = item.CarPartPrice * item.QuantityNeeded,
                SubCategoryName = item.SubCategoryName
            });
            selectedPartsSubCategories_Hide.Add(_SelectedSubCategory);
            PartsForShow.Clear();

            bool hideIt = false;
            selectedPartsSubCategories_ForShow.Clear();
            foreach (var x in selectedPartsSubCategories)
            {
                hideIt = false;
                foreach(var h in selectedPartsSubCategories_Hide)
                {
                    if (x.SubCategoryName == h.SubCategoryName)
                        hideIt = true;
                }
                if (!hideIt)
                    selectedPartsSubCategories_ForShow.Add(x);
            }
        }
        //public async bool ChangeToSelected()
        //{
        //    public bool success = false;
        //public Data.Model.OfferItems model;
        //OfferItemsInsertRequest req = new OfferItemsInsertRequest()
        //{

        //};

        public int Count_SelectedParts()
        {
            return _selectedParts.Count();
        }
        public async Task ChangeToSelected()
        {

          


            Data.Model.OfferItems model;
            OfferItemsInsertRequest req = new OfferItemsInsertRequest()
            {
                OfferID = 0
            };

        foreach(var x in _selectedParts)
            {
                model = await _offerItemsUpdateService.Update<Data.Model.OfferItems>(x.ItemID, req);
            }
            OfferInsertRequest reqs = new OfferInsertRequest();
            await _offerService.Update<Data.Model.Offer>(OfferVM.OfferID, reqs);

         }

    //foreach(var x in _selectedParts)
    //{
    //   //model = await _offerItemsUpdateService.Update<Data.Model.OfferItems>(x. );
    //}



}
}

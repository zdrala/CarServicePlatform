using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IOfferService
    {
        public List<Data.ViewModel.OffersVM> Get(OfferSearchRequest req);
        public Data.Model.Offer Insert(OfferInsertRequest req);

        public Data.Model.Offer Update(int id, OfferInsertRequest req);
        
    }
}

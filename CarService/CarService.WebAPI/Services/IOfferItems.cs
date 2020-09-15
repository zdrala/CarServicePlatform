using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IOfferItems
    {
        Data.ViewModel.OfferItemsVM GetbyID(int id);
        Data.Model.OfferItems Insert(OfferItemsInsertRequest req);

        Data.Model.OfferItems Update(int id,OfferItemsInsertRequest req);
    }
}

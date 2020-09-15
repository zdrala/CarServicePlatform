using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IOfferItemsByClientService
    {
        Data.ViewModel.OfferItemsVM GetbyID(int id);
        Data.Model.OfferItems Insert(OfferItemsInsertRequest req);
    }
}

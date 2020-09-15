using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.Data.ViewModel;
using CarService.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarService.WebAPI.Controllers
{

    public class CarPartsController : BaseCRUDController<Data.ViewModel.CarPartsVM, Data.Requests.CarPartsSearchRequest, Data.Requests.CarPartsUpsertRequest, Data.Requests.CarPartsUpsertRequest>
    {
        public CarPartsController(ICRUDService<CarPartsVM, CarPartsSearchRequest, CarPartsUpsertRequest, CarPartsUpsertRequest> service) : base(service)
        {
        }
    }
}
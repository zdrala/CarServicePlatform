using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data.Model;
using CarService.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarService.WebAPI.Controllers
{

    public class CarPartSubCategoryController : BaseController<Data.Model.CarPartSubCategory, Data.Requests.CarPartsSearchRequest>
    {
        public CarPartSubCategoryController(IBaseService<CarPartSubCategory, Data.Requests.CarPartsSearchRequest> service) : base(service)
        {
        }
    }
}
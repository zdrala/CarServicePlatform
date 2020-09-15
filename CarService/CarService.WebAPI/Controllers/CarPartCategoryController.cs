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

    public class CarPartCategoryController : BaseController<Data.Model.CarPartCategory, object>
    {
        public CarPartCategoryController(IBaseService<CarPartCategory, object> service) : base(service)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarBrandsController : ControllerBase
    {
        private readonly ICarBrandsService _service;

        public CarBrandsController(ICarBrandsService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Data.Model.CarBrands> Get()
        {
            return _service.Get();
        }
    }
}
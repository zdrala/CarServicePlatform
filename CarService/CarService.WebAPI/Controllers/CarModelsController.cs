using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data.Requests;
using CarService.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarModelsController : ControllerBase
    {
        private readonly ICarModelsService _service;
        public CarModelsController(ICarModelsService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Data.Model.CarModels> Get([FromQuery]CarModelsSearchRequest req)
        {
            return _service.Get(req);
        }
        [HttpGet("{id}")]
        public Data.Model.CarModels GetByID(int id)
        {
            return _service.GetByID(id);
        }
    }
}
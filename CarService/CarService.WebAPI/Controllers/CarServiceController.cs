using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.WebAPI.Database;
using CarService.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace CarService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarServiceController : ControllerBase
    {
        private readonly ICarService _service;
        public CarServiceController(ICarService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Data.Model.CarService> Get([FromQuery]CarServiceSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Data.Model.CarService GetByID(int id)
        {
            return _service.GetByID(id);
        }

        [HttpPost]
        public Data.Model.CarService Insert([FromBody]CarServiceUpsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public Data.Model.CarService Update(int id,[FromBody]CarServiceUpsertRequest request)
        {
            return _service.Update(id,request);
        }
    }
}
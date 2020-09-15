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
    public class CarServiceRegisterController : ControllerBase
    {
        private readonly ICarService _service;
        public CarServiceRegisterController(ICarService service)
        {
            _service = service;
        }


        [HttpPost]
        public Data.Model.CarService Insert([FromBody]CarServiceUpsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}
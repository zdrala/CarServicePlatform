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
    public class CountCompletedServicesByDateController : ControllerBase
    {
        private readonly ICompletedServicesByDateService _service;
        public CountCompletedServicesByDateController(ICompletedServicesByDateService service)
        {
            _service = service;
        }
        [HttpGet]
        public Data.Model.CountCompletedServices Get([FromQuery]CompletedServicesSearchByDateRequest req)
        {
            return _service.Get(req);
        }
    }
}
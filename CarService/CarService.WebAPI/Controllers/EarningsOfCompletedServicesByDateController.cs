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
    public class EarningsOfCompletedServicesByDateController : ControllerBase
    {
        private readonly IEarningsOfCompletedServicesByDate _service;
        public EarningsOfCompletedServicesByDateController(IEarningsOfCompletedServicesByDate service)
        {
            _service = service;
        }
        [HttpGet]
        public Data.Model.EarningsOfCompletedServices Get([FromQuery]CompletedServicesSearchByDateRequest req)
        {
            return _service.Get(req);
        }
    }
}
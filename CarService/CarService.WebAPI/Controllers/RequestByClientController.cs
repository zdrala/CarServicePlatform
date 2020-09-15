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
    public class RequestByClientController : ControllerBase
    {
        private readonly IRequestServiceByClientService _service;
        public RequestByClientController(IRequestServiceByClientService service)
        {
            _service = service;
        }


        [HttpGet]
        public List<Data.ViewModel.RequestVM> Get()
        {
            return _service.Get();
        }
        [HttpGet("{id}")]
        public Data.ViewModel.RequestVM GetByID(int id)
        {
            return _service.GetByID(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CarService.Data.Model;
using CarService.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarService.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService _service;
        public CitiesController(ICitiesService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Cities> Get()
        {
            return _service.Get();
        }
        [HttpGet("{id}")]
        public Data.Model.Cities GetByID(int id)
        {
            return _service.GetByID(id);
        }
        
    }
}
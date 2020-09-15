using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController :ControllerBase
    {
        private readonly IRequestService _service;
        public RequestController(IRequestService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Data.Model.Request> Get([FromQuery]RequestSearch request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Data.Model.Request GetByID(int id)
        {
            return _service.GetByID(id);
        }
         [HttpPut("{id}")]
        public Data.Model.Request Update(int id,RequestUpsert req)
        {
            return _service.Update(id,req);
        }
        [HttpPost]
        public Data.Model.Request Insert(RequestUpsert request)
        {
            return _service.Insert(request);
        }
        
    }
}
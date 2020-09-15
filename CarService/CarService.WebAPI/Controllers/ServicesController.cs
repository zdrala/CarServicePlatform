using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarService.Data.Requests;
namespace CarService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServices _service;
        public ServicesController(IServices service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Data.Model.Services> Get([FromQuery]ServicesSearchRequest req)
        {
            return _service.Get(req);
        }
        [HttpGet("{id}")]
        public Data.Model.Services GetByID(int id)
        {
            return _service.GetByID(id);
        }

        [HttpPost]
        public Data.Model.Services Insert(ServicesInsertUpdateRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public Data.Model.Services Update(int id,ServicesInsertUpdateRequest request)
        {
            return _service.Update(id,request);
        }
    }
}
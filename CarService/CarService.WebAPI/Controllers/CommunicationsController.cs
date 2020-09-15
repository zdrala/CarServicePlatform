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
    public class CommunicationsController : ControllerBase
    {
        private readonly ICommunicationService _service;
        public CommunicationsController(ICommunicationService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Data.Model.Communication> Get([FromQuery]CommunicationsSearchRequest req)
        {
            return _service.Get(req); 
        }
        [HttpGet("{id}")]
        public Data.Model.Communication GetByID(int id)
        {
            return _service.GetByID(id);
        }
        [HttpPut("{id}")]
        public Data.Model.Communication Update(int id,[FromBody]CommunicationUpsertRequest req)
        {
            return _service.Update(id, req);
        }
        [HttpPost]
        public Data.Model.Communication Insert([FromBody]CommunicationUpsertRequest req)
        {
            return _service.Insert(req);
        }
    }
}
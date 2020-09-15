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
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;
        public TicketController(ITicketService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Data.Model.Ticket> Get([FromQuery]TicketSearchRequest req)
        {
            return _service.Get(req);
        }
        [HttpPost]
        public Data.Model.Ticket Insert([FromBody]TicketInsertRequest req)
        {
            return _service.Insert(req);
        }
        [HttpPut("{id}")]
        public Data.Model.Ticket Update(int id)
        {
            return _service.Update(id);
        }
    }
}
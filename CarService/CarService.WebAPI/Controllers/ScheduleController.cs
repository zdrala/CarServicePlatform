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
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _service;
        public ScheduleController(IScheduleService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Data.Model.Schedule> Get([FromQuery]ScheduleRequest request)
        {
            return _service.Get(request);
        }
        [HttpGet("{id}")]
        public Data.ViewModel.ScheduleVM GetById(int id)
        {
            return _service.GetById(id);
        }
        [HttpPost]
        public Data.Model.Schedule Insert([FromBody]ScheduleUpsertRequest request)
        {
            return _service.Insert(request);
        }
        [HttpPut("{id}")]
        public Data.Model.Schedule Update(int id,[FromBody]ScheduleUpsertRequest request)
        {
            return _service.Update(id, request);
        }
        [HttpDelete("{id}")]
        public Data.Model.Schedule Delete(int id)
        {
            return _service.Delete(id);
        }

    }
}
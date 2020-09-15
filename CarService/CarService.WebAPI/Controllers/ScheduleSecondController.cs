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
    public class ScheduleSecondController : ControllerBase
    {
        private readonly IScheduleSecondService _service;
        public ScheduleSecondController(IScheduleSecondService service)
        {
            _service = service;
        }
        [HttpPut("{id}")]
        public Data.Model.Schedule Update(int id, [FromBody]ScheduleSecondUpdateRequest req)
        {
            return _service.Update(id, req);
        }
    }
}
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
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsService _service;
        public RatingsController(IRatingsService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<Data.Model.Ratings> Get([FromQuery]RatingsSearchRequest req)
        {
            return _service.Get(req);
        }
        [HttpPost]
        public Data.Model.Ratings Insert([FromBody]RatingInsertRequest req)
        {
            return _service.Insert(req);
        }
    }
}
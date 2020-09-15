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
    public class OffersController : ControllerBase
    {
        private readonly IOfferService _service;
        public OffersController(IOfferService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Data.ViewModel.OffersVM> Get([FromQuery]OfferSearchRequest req)
        {
            return _service.Get(req);
        }
        [HttpPost]
        public Data.Model.Offer Insert([FromBody]OfferInsertRequest req)
        {
            return _service.Insert(req);
        }
        [HttpPut("{id}")]
        public Data.Model.Offer Update(int id,OfferInsertRequest req)
        {
            return _service.Update(id,req);
        }
    }
}
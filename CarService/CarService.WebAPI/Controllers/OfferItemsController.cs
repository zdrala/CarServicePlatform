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
    public class OfferItemsController : ControllerBase
    {
        private readonly IOfferItems _service;
        public OfferItemsController(IOfferItems service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public Data.ViewModel.OfferItemsVM GetbyId(int id)
        {
            return _service.GetbyID(id);
        }
        [HttpPost]
        public Data.Model.OfferItems Insert(OfferItemsInsertRequest req)
        {
            return _service.Insert(req);
        }
        [HttpPut("{id}")]
        public Data.Model.OfferItems Update(int id,OfferItemsInsertRequest req)
        {
            return _service.Update(id,req);
        }
    }
}
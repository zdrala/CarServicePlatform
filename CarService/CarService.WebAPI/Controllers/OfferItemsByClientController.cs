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
    public class OfferItemsByClientController : ControllerBase
    {
        private readonly IOfferItemsByClientService _service;
        public OfferItemsByClientController(IOfferItemsByClientService service)
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
    }
}
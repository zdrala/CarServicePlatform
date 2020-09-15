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
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;
        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Data.Model.Payments> Get([FromQuery]PaymentSearchRequest req)
        {
            return _service.Get(req);
        }
        [HttpPost]
        public Data.Model.Payments Insert([FromBody]PaymentInsertRequest req)
        {
            return _service.Insert(req);
        }
    }
}
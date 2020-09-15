using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegisteringController : ControllerBase
    {
        private readonly IUserService _service;
        public UserRegisteringController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Users> Get([FromQuery]UserSearchRequest request)
        {
            return _service.Get(request);
        }
        [HttpPost]
        public Data.Model.Users Insert([FromBody]UserInsertUpdateRequest request)
        {
            return _service.Insert(request);
        }
    }
}
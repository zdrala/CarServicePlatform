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
    public class UserRegisterController : ControllerBase
    {
        private readonly IUserService _service;
        public UserRegisterController(IUserService service)
        {
            _service = service;
        }
  

        [HttpPost]
        public Users Insert([FromBody]UserInsertUpdateRequest request)
        {
            return _service.Insert(request);
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.WebAPI.Services;
using CarService.Data.Requests;
using CarService.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CarService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Users> Get([FromQuery]UserSearchRequest request)
        {
            return _service.Get(request);
        }

 
        [HttpPost]
        public Users Insert([FromBody]UserInsertUpdateRequest request)
        {
            return _service.Insert(request);
        }

        
        [HttpPut("{id}")]
        public Users Update(int id, UserInsertUpdateRequest request)
        {
            return _service.Update(id, request);
        }

        [HttpGet("{id}")]
        public Users GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
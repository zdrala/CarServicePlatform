using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IUserService
    {
        List<Data.Model.Users> Get(UserSearchRequest request);


        Data.Model.Users GetById(int id);

        Data.Model.Users Insert(UserInsertUpdateRequest request);

        Data.Model.Users Update(int id, UserInsertUpdateRequest request);

        Data.Model.Users Authenticate(string username, string pass);
    }
}

using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IRequestService
    {
        List<Data.Model.Request> Get(RequestSearch req);
        Data.Model.Request GetByID(int id);


        Data.Model.Request Update(int id, RequestUpsert request);
        Data.Model.Request Insert(RequestUpsert request);

    }
}

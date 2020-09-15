using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data.Requests;
namespace CarService.WebAPI.Services
{
    public interface IServices
    {
        List<Data.Model.Services> Get(ServicesSearchRequest req);
        Data.Model.Services GetByID(int id);

        Data.Model.Services Insert(ServicesInsertUpdateRequest request);
        Data.Model.Services Update(int id,ServicesInsertUpdateRequest request);
    }
}

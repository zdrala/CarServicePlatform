using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.WebAPI.Database;
using CarService.Data.Requests;
using CarService.Data.Model;
namespace CarService.WebAPI.Services
{
    public interface ICarService
    {
        List<Data.Model.CarService> Get(CarServiceSearchRequest request);
        Data.Model.CarService GetByID(int id);

        Data.Model.CarService Insert(CarServiceUpsertRequest request);
        Data.Model.CarService Update(int id,CarServiceUpsertRequest request);
    }
}

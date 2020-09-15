using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
   public interface ICarModelsService
    {
        List<Data.Model.CarModels> Get(CarModelsSearchRequest req);
        Data.Model.CarModels GetByID(int id);
    }
}

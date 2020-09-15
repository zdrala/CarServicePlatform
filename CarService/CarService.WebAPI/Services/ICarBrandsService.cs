using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface ICarBrandsService
    {
        List<Data.Model.CarBrands> Get();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface ICitiesService
    {
        List<Data.Model.Cities> Get();
        Data.Model.Cities GetByID(int id);
    }
}

using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IEarningsOfCompletedServicesByDate
    {
        Data.Model.EarningsOfCompletedServices Get(CompletedServicesSearchByDateRequest req);
    }
}

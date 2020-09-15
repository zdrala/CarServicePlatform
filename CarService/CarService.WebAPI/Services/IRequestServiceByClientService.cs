using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IRequestServiceByClientService
    {
        Data.ViewModel.RequestVM GetByID(int id);

        List<Data.ViewModel.RequestVM> Get();
    }
}

using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IScheduleService
    {
        List<Data.Model.Schedule> Get(ScheduleRequest req);
        Data.Model.Schedule Insert(ScheduleUpsertRequest req);

        Data.ViewModel.ScheduleVM GetById(int id);

        Data.Model.Schedule Update(int id, ScheduleUpsertRequest req);

        Data.Model.Schedule Delete(int id);

    }
}

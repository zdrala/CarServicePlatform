using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IScheduleSecondService
    {
        Data.Model.Schedule Update(int id, ScheduleSecondUpdateRequest req);
    }
}

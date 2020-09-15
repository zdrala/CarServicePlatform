using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public class CountCompletedServicesByDateService : ICompletedServicesByDateService
    {
        private readonly CarServiceContext _context;

        public CountCompletedServicesByDateService(CarServiceContext context)
        {
            _context = context;
        }

        public CountCompletedServices Get(CompletedServicesSearchByDateRequest req)
        {
            var entityServicesList = _context.Services.Where(s => s.CarServiceID == req.carServiceID).ToList();
            var model = new Data.Model.CountCompletedServices();
            model.servicesList = new List<Data.Model.CountCompletedServices.Service>();
            foreach (var x in entityServicesList)
            {
                model.servicesList.Add(new Data.Model.CountCompletedServices.Service()
                {
                    serviceID = x.ServiceID,
                    ServiceName = x.ServiceName,
                    Count = 0
                });
            }
            var entitySchedulesList = _context.Schedules.Include(s => s.Request).Where(s => s.DateofSchedule>= req.DateFrom && 
            s.DateofSchedule <= req.DateTo && s.ScheduleStatusID == 2&&s.Request.CarServiceID==req.carServiceID).ToList();
            foreach(var s in entitySchedulesList)
            {
                var listScheduleServices = _context.requestServices.Where(r => r.RequestID == s.RequestID).ToList();

                foreach(var l in listScheduleServices)
                {
                    foreach(var serviceCheck in model.servicesList)
                    {
                        if(serviceCheck.serviceID==l.ServiceID)
                        {
                            serviceCheck.Count++;
                        }

                    }
                }
            }


            var newModel = new Data.Model.CountCompletedServices();
            newModel.servicesList = new List<Data.Model.CountCompletedServices.Service>();
            foreach(var m in model.servicesList)
            {
                if(m.Count>0)
                {
                    newModel.servicesList.Add(new Data.Model.CountCompletedServices.Service()
                    {
                        serviceID=m.serviceID,
                        ServiceName=m.ServiceName,
                        Count=m.Count
                    });
                }
            }
            return newModel;
        }
    }
}

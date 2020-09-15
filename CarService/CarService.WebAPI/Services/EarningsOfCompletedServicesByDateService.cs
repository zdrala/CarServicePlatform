using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace CarService.WebAPI.Services
{
    public class EarningsOfCompletedServicesByDateService : IEarningsOfCompletedServicesByDate
    {
        private readonly CarServiceContext _context;
        public EarningsOfCompletedServicesByDateService(CarServiceContext context)
        {
            _context = context;
        }
        public EarningsOfCompletedServices Get(CompletedServicesSearchByDateRequest req)
        {
            var entityServicesList = _context.Services.Where(s => s.CarServiceID == req.carServiceID).ToList();
            var model = new Data.Model.EarningsOfCompletedServices();
            model.servicesList = new List<Data.Model.EarningsOfCompletedServices.Service>();
            foreach (var x in entityServicesList)
            {
                model.servicesList.Add(new Data.Model.EarningsOfCompletedServices.Service()
                {
                    serviceID = x.ServiceID,
                    ServiceName = x.ServiceName,
                    Earnings=0
                });
            }
            var entitySchedulesList = _context.Schedules.Include(s => s.Request).Where(s => s.DateofSchedule >= req.DateFrom &&
            s.DateofSchedule <= req.DateTo && s.ScheduleStatusID == 2 && s.Request.CarServiceID == req.carServiceID).ToList();
            foreach (var s in entitySchedulesList)
            {
                var listScheduleServices = _context.requestServices.Include(r=>r.Service).Where(r => r.RequestID == s.RequestID).ToList();

                foreach (var l in listScheduleServices)
                {
                    foreach (var serviceCheck in model.servicesList)
                    {
                        if (serviceCheck.serviceID == l.ServiceID)
                        {
                            serviceCheck.Earnings+=l.Service.ServicePrice;
                        }

                    }
                }
            }


            var newModel = new Data.Model.EarningsOfCompletedServices();
            newModel.servicesList = new List<Data.Model.EarningsOfCompletedServices.Service>();
            foreach (var m in model.servicesList)
            {
                if (m.Earnings > 0)
                {
                    newModel.servicesList.Add(new Data.Model.EarningsOfCompletedServices.Service()
                    {
                        serviceID = m.serviceID,
                        ServiceName = m.ServiceName,
                        Earnings=m.Earnings
                    });
                }
            }
            return newModel;
        }
    }
}

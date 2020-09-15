using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarService.Data.ViewModel;
using CarService.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace CarService.WebAPI.Services
{
    public class RequestServiceByClientService : IRequestServiceByClientService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public RequestServiceByClientService(CarServiceContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<RequestVM> Get()
        {
            var list = _context.Requests.Include(r => r.User).ThenInclude(r => r.CarModel).Where(r => r.RequestStatusID == 1).OrderBy(r => r.DateOfRequest).ToList();
            var modelList = new List<Data.ViewModel.RequestVM>();

            foreach (var x in list)
            {
                var model = new Data.ViewModel.RequestVM()
                {
                    RequestID = x.RequestID,
                    DateOfRequest = x.DateOfRequest,
                    Date = x.DateOfRequest.Day + "." + x.DateOfRequest.Month + "." + x.DateOfRequest.Year,
                    UserID = x.UserID,
                    UserNameLastName = x.User.FirstName + " " + x.User.LastName,
                    UserCar = x.User.CarModel.CarModelName,
                    CarServiceID = x.CarServiceID,
                    StatusID = x.RequestStatusID,


                };
                var ServicesList = _context.requestServices.Include(s => s.Service).Where(s => s.RequestID == x.RequestID).ToList();
                model.ListOfRequestedServices = new List<Data.ViewModel.RequestVM.Service>();
                foreach (var s in ServicesList)
                {
                    model.ListOfRequestedServices.Add(new Data.ViewModel.RequestVM.Service() 
                    {
                        serviceID=s.Service.ServiceID,
                    ServiceName=s.Service.ServiceName,
                        ServicePrice=s.Service.ServicePrice
                    });
                }
                modelList.Add(model);
            }
            return modelList;
        }

        public RequestVM GetByID(int id)
        {
            var x = _context.Requests.Include(r => r.User).ThenInclude(r => r.CarModel).Where(r => r.RequestID == id).SingleOrDefault();



            var model = new Data.ViewModel.RequestVM()
            {
                RequestID = x.RequestID,
                DateOfRequest = x.DateOfRequest,
                Date = x.DateOfRequest.Day + "." + x.DateOfRequest.Month + "." + x.DateOfRequest.Year,
                UserID = x.UserID,
                UserNameLastName = x.User.FirstName + " " + x.User.LastName,
                UserCar = x.User.CarModel.CarModelName,
                CarServiceID = x.CarServiceID,
                StatusID = x.RequestStatusID,


            };
            var ServicesList = _context.requestServices.Include(s => s.Service).Where(s => s.RequestID == x.RequestID).ToList();
            model.ListOfRequestedServices = new List<Data.ViewModel.RequestVM.Service>();
            foreach (var s in ServicesList)
            {
                model.ListOfRequestedServices.Add(new RequestVM.Service()
                {
                    serviceID=s.ServiceID,
                    ServiceName=s.Service.ServiceName,
                    ServicePrice=s.Service.ServicePrice
                });
            }


            return model;
        }
    }
}

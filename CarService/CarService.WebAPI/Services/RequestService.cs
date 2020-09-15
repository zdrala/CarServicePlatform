using AutoMapper;
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
    public class RequestService : IRequestService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public RequestService(CarServiceContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<Data.Model.Request> Get(RequestSearch request)
        {
            var list = _context.Requests.Include(r => r.User).ThenInclude(r => r.CarModel).Where(r => r.RequestStatusID == 1 && request.carserviceID == r.CarServiceID).OrderBy(r => r.DateOfRequest).ToList();
            var modelList = new List<Data.Model.Request>();

            foreach (var x in list)
            {
                var model = new Data.Model.Request()
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
                model.ListOfRequestedServices = new List<string>();
                foreach (var s in ServicesList)
                {
                    model.ListOfRequestedServices.Add(s.Service.ServiceName);
                }
                modelList.Add(model);
            }
            return modelList;

        }
        public Data.Model.Request GetByID(int id)
        {
            var x = _context.Requests.Include(r => r.User).ThenInclude(r => r.CarModel).Where(r => r.RequestID == id).SingleOrDefault();



            var model = new Data.Model.Request()
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
            model.ListOfRequestedServices = new List<string>();
            foreach (var s in ServicesList)
            {
                model.ListOfRequestedServices.Add(s.Service.ServiceName);
            }


            return model;
        }

        public Data.Model.Request Insert(RequestUpsert request)
        {
            var entity = _mapper.Map<Database.Request>(request);
            _context.Requests.Add(entity);
            _context.SaveChanges();
            var x = _context.Requests.Include(r => r.User).ThenInclude(r => r.CarModel).Where(r=>r.RequestID==entity.RequestID).SingleOrDefault();

            foreach(var o in request._selectedServicesList)
            {
                _context.requestServices.Add(new Database.RequestServices()
                {
                    RequestID=x.RequestID,
                    ServiceID=o.ServiceID
                });
                _context.SaveChanges();
            }
            var model = new Data.Model.Request()
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
            model.ListOfRequestedServices = new List<string>();
            foreach (var s in ServicesList)
            {
                model.ListOfRequestedServices.Add(s.Service.ServiceName);
            }
            return model;
        }

        public Data.Model.Request Update(int id, RequestUpsert request)
        {
            var x = _context.Requests.Include(r => r.User).ThenInclude(r => r.CarModel).Where(r => r.RequestID == id).SingleOrDefault();
            _context.Requests.Attach(x);
            _context.Requests.Update(x);

            x.RequestStatusID = request.RequestStatusID;
            _context.SaveChanges();

            var model = new Data.Model.Request()
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
            model.ListOfRequestedServices = new List<string>();
            foreach (var s in ServicesList)
            {
                model.ListOfRequestedServices.Add(s.Service.ServiceName);
            }
            return model;
        }
    }
}

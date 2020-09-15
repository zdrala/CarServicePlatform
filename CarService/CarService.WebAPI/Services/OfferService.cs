using AutoMapper;
using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.Data.ViewModel;
using CarService.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public class OfferService : IOfferService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public OfferService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<OffersVM> Get(OfferSearchRequest req)
        {
            var query = _context.Offers.Include(o=>o.Schedule).ThenInclude(s=>s.ScheduleStatus).Include(s=>s.Schedule.Request).ThenInclude(r=>r.User).ThenInclude(u=>u.CarModel).AsQueryable();
            var list=new List<Database.Offers>();
            var modelList = new List<Data.ViewModel.OffersVM>();

            if(req.ScheduleID>0)
            {
                query = query.Where(o=>o.ScheduleID==req.ScheduleID);
                list = query.ToList();
                foreach (var x in list)
                {
                    modelList.Add(new Data.ViewModel.OffersVM()
                    {
                        ScheduleID = x.Schedule.ScheduleID,
                        RequestID = x.Schedule.RequestID,
                        DateofSchedule = x.Schedule.DateofSchedule,
                        Date = x.Schedule.DateofSchedule.Day + " " + x.Schedule.DateofSchedule.Month + "." + x.Schedule.DateofSchedule.Year,
                        ScheduleStatusID = x.Schedule.ScheduleStatusID,
                        Status = x.Schedule.ScheduleStatus.name,
                        isPaid = x.Schedule.isPaid,
                        totalPrice = x.Schedule.totalPrice,
                        User = x.Schedule.Request.User.FirstName + " " + x.Schedule.Request.User.LastName,
                        OfferID = x.OfferID,
                        isLocked = x.isLocked,
                        partsSelected = x.partsSelected,
                        UserCar = x.Schedule.Request.User.CarModel.CarModelName

                    });
                }
                return modelList;
            }

            if(req.AdminSearch)
            {
                query = query.Where(o => o.Schedule.ScheduleStatusID == 1 && o.partsSelected == true&&o.Schedule.Request.CarServiceID==req.CarServiceID);
                list = query.OrderBy(o=>o.Schedule.DateofSchedule).ToList();
            }

            foreach(var x in list)
            {
                /*
                  public int ScheduleID { get; set; }

        public int RequestID { get; set; }

        public DateTime DateofSchedule { get; set; }

        public string Date { get; set; }
        public int ScheduleStatusID { get; set; } //napraviti referentnu za statuse

        public string Status { get; set; }

        public bool isPaid { get; set; }

        public double totalPrice { get; set; }

        public string User { get; set; }
        public int OfferID { get; set; }

        public bool isLocked { get; set; }

        public bool partsSelected { get; set; }//from user
                 */
                modelList.Add(new Data.ViewModel.OffersVM()
                {
                    ScheduleID = x.Schedule.ScheduleID,
                    RequestID = x.Schedule.RequestID,
                    DateofSchedule=x.Schedule.DateofSchedule,
                    Date=x.Schedule.DateofSchedule.Day+" "+x.Schedule.DateofSchedule.Month+"."+x.Schedule.DateofSchedule.Year,
                    ScheduleStatusID=x.Schedule.ScheduleStatusID,
                    Status=x.Schedule.ScheduleStatus.name,
                    isPaid=x.Schedule.isPaid,
                    totalPrice=x.Schedule.totalPrice,
                    User=x.Schedule.Request.User.FirstName+" "+x.Schedule.Request.User.LastName,
                    OfferID=x.OfferID,
                    isLocked=x.isLocked,
                    partsSelected=x.partsSelected,
                    UserCar=x.Schedule.Request.User.CarModel.CarModelName

                });
            }
            return modelList;
        }

        public Offer Insert(OfferInsertRequest req)
        {
            var entity = _mapper.Map<Database.Offers>(req);
            _context.Offers.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Data.Model.Offer>(entity);
        }

        public Offer Update(int id, OfferInsertRequest req)
        {
            var entity = _context.Offers.Find(id);
            _context.Attach(entity);
            _context.Update(entity);
            entity.isLocked = true;
            entity.partsSelected = true;
            _context.SaveChanges();
            return _mapper.Map<Data.Model.Offer>(entity);
        }
    }
}

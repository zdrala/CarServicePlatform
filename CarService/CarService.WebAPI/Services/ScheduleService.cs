using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.Data.ViewModel;
using CarService.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace CarService.WebAPI.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public ScheduleService(CarServiceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Data.Model.Schedule Delete(int id)
        {
            var scheduleEntity = _context.Schedules.Find(id);

            var offerEntity = _context.Offers.Where(o => o.ScheduleID == id).SingleOrDefault();
            var offerItems = _context.OfferItems.Where(i => i.OfferID == offerEntity.OfferID).ToList();

            foreach(var x in offerItems)
            {
                _context.OfferItems.Remove(x);
            }
            var o = scheduleEntity;
            _context.Offers.Remove(offerEntity);
            _context.Schedules.Remove(scheduleEntity);
            _context.SaveChanges();
            return _mapper.Map<Data.Model.Schedule>(o);
        }

        public List<Data.Model.Schedule> Get(ScheduleRequest req)
        {
            var query = _context.Schedules.Include(s => s.ScheduleStatus).Include(s => s.Request).ThenInclude(r=>r.User).Include(s=>s.Request.CarService).AsQueryable();


            if(req.userName!=null)
            {
                query = query.Where(x => x.Request.User.FirstName==req.userName);
            }
            if (req.userLastName != null)
            {
                query = query.Where(x => x.Request.User.LastName==req.userLastName);
            }
            var list=new List<WebAPI.Database.Schedule>();
            if (req.userName != null || req.userLastName != null)
            {
                if(req.AdminSearch)
                 list = query.Where(s=>s.Request.CarServiceID==req.CarServiceID).OrderBy(s => s.DateofSchedule).ToList();
                else
                    list = query.OrderBy(s => s.DateofSchedule).ToList();
            }
            else
            {
                if(req.AdminSearch)
                list = query.Where(s=>s.ScheduleStatusID==req.ScheduleStatusID&& s.Request.CarServiceID == req.CarServiceID).OrderBy(s => s.DateofSchedule).ToList();
                else
                  list = query.Where(s => s.ScheduleStatusID == req.ScheduleStatusID).OrderBy(s => s.DateofSchedule).ToList();
            }
            var modelList = new List<Data.Model.Schedule>();
            foreach(var x in list)
            {
                var model = new Data.Model.Schedule()
                {
                    ScheduleID=x.ScheduleID,
                    RequestID=x.RequestID,
                    DateofSchedule=x.DateofSchedule,
                    ScheduleStatusID=x.ScheduleStatusID,
                    Status=x.ScheduleStatus.name,
                    isPaid=x.isPaid,
                    totalPrice=x.totalPrice,
                    User=x.Request.User.FirstName+" "+x.Request.User.LastName,
                    CarServiceName=x.Request.CarService.CarServiceName,
                    Date=x.DateofSchedule.Day+"."+x.DateofSchedule.Month+"."+x.DateofSchedule.Year+" "+x.DateofSchedule.Hour+":"+x.DateofSchedule.Minute
                };
                modelList.Add(model);
            }
            return modelList;

        }

        public ScheduleVM GetById(int id)
        {
            var entity = _context.Schedules.Include(s => s.ScheduleStatus).Include(s => s.Request).ThenInclude(r => r.User).ThenInclude(u=>u.CarModel).Where(s => s.ScheduleID == id).SingleOrDefault();
            var model = new Data.ViewModel.ScheduleVM()
            {
                ScheduleID=entity.ScheduleID,
                RequestID=entity.RequestID,
                DateofSchedule=entity.DateofSchedule,
                Date=entity.DateofSchedule.Day+"."+entity.DateofSchedule.Month+"."+entity.DateofSchedule.Year+" "+entity.DateofSchedule.Hour+":"+entity.DateofSchedule.Minute,
                ScheduleStatusID=entity.ScheduleStatusID,
                Status=entity.ScheduleStatus.name,
                isPaid=entity.isPaid,
                totalPrice=entity.totalPrice,
                User=entity.Request.User.FirstName+" "+entity.Request.User.LastName,
                UserCar=entity.Request.User.CarModel.CarModelName
            };
            var offerEntity = _context.Offers.Where(o => o.ScheduleID == id).SingleOrDefault();
            if (offerEntity != null)
                model.offerCreated = true;
            else
                model.offerCreated = false;
            

            if (entity.isPaid)
                model.isPaidString = "DA";
            else
                model.isPaidString = "NE";
            var OfferItemsListSelected = new List<Database.OfferItems>();
            if (offerEntity != null)
            {
                OfferItemsListSelected = _context.OfferItems.Include(i => i.CarPart).ThenInclude(i=>i.SubCategory).Where(i => i.OfferID == offerEntity.OfferID).ToList();
            }
            var ItemsForSelect = _context.CarParts.Include(c => c.SubCategory).Where(c => c.CarServiceID == entity.Request.CarServiceID).Select(c=>c.SubCategory).Distinct().ToList();
            model.selectedSubCategories = new List<Data.ViewModel.ScheduleVM.ItemsSelected>();
            foreach(var x in OfferItemsListSelected)
            {
                if (x.CarPart.Quality == "Quality II")
                {
                    model.selectedSubCategories.Add(new Data.ViewModel.ScheduleVM.ItemsSelected()
                    {
                        subCategoryID = x.subCategoryID,
                        SubCategoryName = x.CarPart.SubCategory.SubCategoryName,
                        QuantityNeeded = x.QuantityNeeded
                    });
                }
            }
            model.itemsforSelect = new List<Data.Model.CarPartSubCategory>();
            foreach(var x in ItemsForSelect)
            {
                model.itemsforSelect.Add(new Data.Model.CarPartSubCategory()
                {
                    SubCategoryID=x.SubCategoryID,
                    SubCategoryName=x.SubCategoryName,
                    CategoryID=x.CategoryID
                });
                
            }
            return model;
        }

        public Data.Model.Schedule Insert(ScheduleUpsertRequest request)
        {
            var entity = _mapper.Map<Database.Schedule>(request);

            _context.Schedules.Add(entity);
            _context.SaveChanges();
            var obj = _context.Schedules.Include(s=>s.Request).ThenInclude(r=>r.User).Where(s => s.RequestID == request.RequestID).SingleOrDefault();


            var model = _mapper.Map<Data.Model.Schedule>(obj);

            model.User = obj.Request.User.FirstName + " " + obj.Request.User.LastName;
            return model;
        }

        public Data.Model.Schedule Update(int id, ScheduleUpsertRequest req)
        {
            var entity = _context.Schedules.Find(id);

            _context.Schedules.Attach(entity);
            _context.Schedules.Update(entity);

            _mapper.Map(req, entity);
            _context.SaveChanges();

            return _mapper.Map<Data.Model.Schedule>(entity);
        }
    }
}

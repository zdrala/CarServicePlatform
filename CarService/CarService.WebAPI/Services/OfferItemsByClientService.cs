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
    public class OfferItemsByClientService : IOfferItemsByClientService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public OfferItemsByClientService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public OfferItemsVM GetbyID(int id)
        {
            var o = _context.Offers.Include(o => o.Schedule).ThenInclude(s => s.ScheduleStatus).Include(o => o.Schedule.Request).ThenInclude(r => r.User).ThenInclude(u => u.CarModel).
          Where(o => o.OfferID == id).SingleOrDefault();
            var query = _context.OfferItems.Include(i => i.CarPart).ThenInclude(c => c.SubCategory).AsQueryable();
            var list = new List<Database.OfferItems>();
            var modelList = new List<Data.ViewModel.OfferItemsVM>();

            query = query.Where(i => i.OfferID == id);
            list = query.OrderBy(i => i.CarPart.Name).ToList();



            var model = new Data.ViewModel.OfferItemsVM()
            {
                Date = o.Schedule.DateofSchedule.Day + "." + o.Schedule.DateofSchedule.Month + "." + o.Schedule.DateofSchedule.Year + " " + o.Schedule.DateofSchedule.Hour + ":" + o.Schedule.DateofSchedule.Minute,
                Status = o.Schedule.ScheduleStatus.name,
                User = o.Schedule.Request.User.FirstName + " " + o.Schedule.Request.User.LastName,
                UserCar = o.Schedule.Request.User.CarModel.CarModelName,
                OfferID = o.OfferID
            };
            model.listOfParts = new List<Data.ViewModel.OfferItemsVM.Parts>();
            foreach (var x in list)
            {
                model.listOfParts.Add(new Data.ViewModel.OfferItemsVM.Parts()
                {
                    ItemID = x.itemID,
                    CarPartID = x.CarPartID,
                    CarPartName = x.CarPart.Name,
                    CarPartPrice = x.CarPart.Price,
                    Quality = x.CarPart.Quality,
                    SubCategoryName = x.CarPart.SubCategory.SubCategoryName,
                    QuantityNeeded = x.QuantityNeeded,
                    IsSelected = x.isSelected,
                    Photo = x.CarPart.Photo
                });


            }
            return model;
        }

        public Data.Model.OfferItems Insert(OfferItemsInsertRequest req)
        {
            var entity = _mapper.Map<Database.OfferItems>(req);
            _context.OfferItems.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Data.Model.OfferItems>(entity);
        }
    }
}

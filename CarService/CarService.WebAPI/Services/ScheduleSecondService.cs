using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.WebAPI.Database;

namespace CarService.WebAPI.Services
{
    public class ScheduleSecondService : IScheduleSecondService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public ScheduleSecondService(CarServiceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Data.Model.Schedule Update(int id, ScheduleSecondUpdateRequest req)
        {
            var entity = _context.Schedules.Find(id);

            _context.Schedules.Attach(entity);
            _context.Schedules.Update(entity);

            if (req.updateTotalPrice)
            {
                entity.totalPrice = req.TotalPrice;
            }
            if(req.updateIsPaid)
            {
                entity.isPaid = true;
            }
            _context.SaveChanges();

            return _mapper.Map<Data.Model.Schedule>(entity);
        }
    }
}

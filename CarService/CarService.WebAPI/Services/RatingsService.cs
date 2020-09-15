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
    public class RatingsService : IRatingsService
    {

        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public RatingsService(CarServiceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Data.Model.Ratings> Get(RatingsSearchRequest req)
        {
            var query = _context.Ratings.AsQueryable();

            if(req.ScheduleID.HasValue)
            {
                query = query.Where(r => r.ScheduleID == req.ScheduleID);
            }
            var list = query.ToList();

            return _mapper.Map<List<Data.Model.Ratings>>(list);
        }

        public Data.Model.Ratings Insert(RatingInsertRequest req)
        {
            var entity = _mapper.Map<Database.Ratings>(req);

            _context.Ratings.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Data.Model.Ratings>(entity);
        }
    }
}

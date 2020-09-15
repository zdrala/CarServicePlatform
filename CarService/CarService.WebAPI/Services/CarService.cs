using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.WebAPI.Database;
using CarService.Data.Requests;
using CarService.Data.Model;
using AutoMapper;

namespace CarService.WebAPI.Services
{
    public class CarService : ICarService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public CarService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Data.Model.CarService> Get(CarServiceSearchRequest request)
        {
            var query = _context.CarServices.AsQueryable();

            if(request.userID==0)
            {
                var list1 = query.ToList();
                return _mapper.Map<List<Data.Model.CarService>>(list1);
            }

            if(request.userID.HasValue)
            {
                query = query.Where(c => c.UserID == request.userID);
            }
            var list = query.ToList();
            return _mapper.Map<List<Data.Model.CarService>>(list);
        }

        public Data.Model.CarService GetByID(int id)
        {
            var entity = _context.CarServices.Find(id);
            return _mapper.Map<Data.Model.CarService>(entity);
        }

        public Data.Model.CarService Insert(CarServiceUpsertRequest request)
        {
            var entity = _mapper.Map<Database.CarService>(request);

            entity.CreatedDate = DateTime.Now;
            entity.NumberOfLikes = 0;
            entity.NumberOfDislikes = 0;
            _context.CarServices.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Data.Model.CarService>(entity);
        }

        public Data.Model.CarService Update(int id, CarServiceUpsertRequest request)
        {
            var entity = _context.CarServices.Find(id);
            _context.CarServices.Attach(entity);
            _context.CarServices.Update(entity);

            if (request.isLiked || request.isDisliked)
            {
                if (request.isLiked)
                    entity.NumberOfLikes++;
                else
                    entity.NumberOfDislikes++;
            }
            else
            {


                entity.CarServiceName = request.CarServiceName;
                entity.Street = request.Street;
                entity.PhoneNumber = request.PhoneNumber;
                entity.Photo = request.Photo;
            }
            _context.SaveChanges();

            return _mapper.Map<Data.Model.CarService>(entity);
        }
    }
}

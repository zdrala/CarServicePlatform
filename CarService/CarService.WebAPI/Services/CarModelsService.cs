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
    public class CarModelsService : ICarModelsService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public CarModelsService(CarServiceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Data.Model.CarModels> Get(CarModelsSearchRequest req)
        {
            var query = _context.CarModels.AsQueryable();

            if(req.CarBrandID.HasValue)
            {
                query = query.Where(m => m.CarBrandID == req.CarBrandID);
            }
            var list = query.OrderBy(m=>m.CarModelName).ToList();

            return _mapper.Map<List<Data.Model.CarModels>>(list);
        }

        public Data.Model.CarModels GetByID(int id)
        {
            var entity = _context.CarModels.Find(id);
            return _mapper.Map<Data.Model.CarModels>(entity);
        }
    }
}

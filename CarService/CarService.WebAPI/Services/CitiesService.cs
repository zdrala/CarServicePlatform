using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarService.Data.Model;
using CarService.WebAPI.Database;

namespace CarService.WebAPI.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public CitiesService(CarServiceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Data.Model.Cities> Get()
        {
            var list = _context.Cities.ToList();
            return _mapper.Map<List<Data.Model.Cities>>(list);
        }

        public Data.Model.Cities GetByID(int id)
        {
            var entity = _context.Cities.Find(id);
            return _mapper.Map<Data.Model.Cities>(entity);
        }
    }
}

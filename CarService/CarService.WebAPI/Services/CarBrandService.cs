using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarService.Data.Model;
using CarService.WebAPI.Database;

namespace CarService.WebAPI.Services
{
    public class CarBrandService : ICarBrandsService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public CarBrandService(CarServiceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Data.Model.CarBrands> Get()
        {
            var list = _context.CarBrands.ToList();

            return _mapper.Map<List<Data.Model.CarBrands>>(list);
        }
    }
}

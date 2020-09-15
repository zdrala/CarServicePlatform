using AutoMapper;
using CarService.Data.Model;
using CarService.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data.Requests;
namespace CarService.WebAPI.Services
{
    public class Services:IServices
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public Services(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Data.Model.Services> Get(ServicesSearchRequest req)
        {
            var query = _context.Services.AsQueryable();

           if(req.CarServiceID.HasValue)
            {
                query = query.Where(s => s.CarServiceID == req.CarServiceID);
            }

            var list = query.OrderBy(s=>s.ServiceName).ToList();
            return _mapper.Map<List<Data.Model.Services>>(list);
        }

        public Data.Model.Services GetByID(int id)
        {
            var entity = _context.Services.Find(id);
            return _mapper.Map<Data.Model.Services>(entity);
        }
        public Data.Model.Services Insert(ServicesInsertUpdateRequest request)
        {
            var entity = _mapper.Map<Database.Services>(request);

          

            _context.Services.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Data.Model.Services>(entity);
        }
        public Data.Model.Services Update(int id,ServicesInsertUpdateRequest request)
        {
            var entity = _context.Services.Find(id);

            _context.Services.Attach(entity);
            _context.Services.Update(entity);


            _mapper.Map(request, entity);

            _context.SaveChanges();

            return _mapper.Map<Data.Model.Services>(entity);
        }
    }
}

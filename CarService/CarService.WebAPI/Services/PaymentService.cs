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
    public class PaymentService : IPaymentService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public PaymentService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Data.Model.Payments> Get(PaymentSearchRequest req)
        {
            var query = _context.Payments.AsQueryable();
            if(req.scheduleID.HasValue)
            {
                query = query.Where(p => p.ScheduleID == req.scheduleID);
            }
            var list = query.ToList();
            return _mapper.Map<List<Data.Model.Payments>>(list);
        }

        public Data.Model.Payments Insert(PaymentInsertRequest req)
        {
            var entity = _mapper.Map<Database.Payments>(req);

            _context.Payments.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<Data.Model.Payments>(entity);
        }
    }
}

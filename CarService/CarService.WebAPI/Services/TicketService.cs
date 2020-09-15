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
    public class TicketService : ITicketService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public TicketService(CarServiceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<Data.Model.Ticket> Get(TicketSearchRequest req)
        {
            var query = _context.Tickets.AsQueryable();
            if(req.ScheduleID.HasValue)
            {
                query = query.Where(t => t.ScheduleID == req.ScheduleID);
            }
            var list = query.ToList();
            return _mapper.Map<List<Data.Model.Ticket>>(list);
        }

        public Data.Model.Ticket Insert(TicketInsertRequest req)
        {
            var entity = _mapper.Map<Database.Ticket>(req);
            _context.Tickets.Add(entity);
            _context.SaveChanges();
            return _mapper.Map<Data.Model.Ticket>(entity);
        }

        public Data.Model.Ticket Update(int id)
        {
            var entity = _context.Tickets.Find(id);
            _context.Attach(entity);
            _context.Update(entity);
            entity.isProccessed = true;
            _context.SaveChanges();
            return _mapper.Map<Data.Model.Ticket>(entity);
        }
    }
}

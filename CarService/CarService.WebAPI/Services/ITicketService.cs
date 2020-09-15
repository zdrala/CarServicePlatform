using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface ITicketService
    {
        Data.Model.Ticket Insert(TicketInsertRequest req);
        Data.Model.Ticket Update(int id);
        List<Data.Model.Ticket> Get(TicketSearchRequest req);
    }
}

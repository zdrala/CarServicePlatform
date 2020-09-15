using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface ICommunicationService
    {
        List<Data.Model.Communication> Get(CommunicationsSearchRequest req);
        Data.Model.Communication GetByID(int id);

        Data.Model.Communication Update(int id, CommunicationUpsertRequest req);
        Data.Model.Communication Insert( CommunicationUpsertRequest req);
    }
}

using CarService.Data.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface IRatingsService
    {
        List<Data.Model.Ratings> Get(RatingsSearchRequest req);

        Data.Model.Ratings Insert(RatingInsertRequest req);
    }
}

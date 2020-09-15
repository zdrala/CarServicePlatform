using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Services
{
    public interface ICRUDService<TModel, TSearch, TInsert, TUpdate>:IBaseService<TModel,TSearch>
    {
        TModel Insert(TInsert request);

        TModel Update(int id, TUpdate request);
    }
}

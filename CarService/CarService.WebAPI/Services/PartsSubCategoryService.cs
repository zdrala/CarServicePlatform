using AutoMapper;
using CarService.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Data.Requests;
namespace CarService.WebAPI.Services
{
    public class PartsSubCategoryService:BaseService<Data.Model.CarPartSubCategory,Data.Requests.CarPartsSearchRequest,CarPartSubCategory>
    {
        public PartsSubCategoryService(CarServiceContext context, IMapper mapper) : base(context, mapper)
        {


        }
        public override List<Data.Model.CarPartSubCategory> Get(CarPartsSearchRequest search)
        {
            var query = _context.Set<CarPartSubCategory>().AsQueryable();

            if (search?.categoryID.HasValue == true)
            {
                query = query.Where(x => x.CategoryID == search.categoryID);
            }

            query = query.OrderBy(x => x.SubCategoryName);

            var list = query.ToList();

            return _mapper.Map<List<Data.Model.CarPartSubCategory>>(list);
        }
    }
}

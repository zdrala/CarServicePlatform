using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarService.Data.Requests;
using CarService.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace CarService.WebAPI.Services
{
    public class CarPartsService : BaseCRUDService<Data.ViewModel.CarPartsVM, Data.Requests.CarPartsSearchRequest, Database.CarParts, Data.Requests.CarPartsUpsertRequest, Data.Requests.CarPartsUpsertRequest>
    {
        public CarPartsService(CarServiceContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override List<Data.ViewModel.CarPartsVM> Get(CarPartsSearchRequest search)
        {
            var query = _context.Set<CarParts>().Include(p=>p.Category).Include(p=>p.SubCategory).AsQueryable();

            if (search?.categoryID.HasValue == true&&search?.subCategoryID.HasValue==false)
            {
                query = query.Where(x => x.CategoryID == search.categoryID);
            }

            if(search?.subCategoryID.HasValue == true)
            {
                query = query.Where(x => x.SubCategoryID == search.subCategoryID);
            }

            query = query.Where(p=>p.CarServiceID==search.CarServiceID).OrderBy(x => x.SubCategory.SubCategoryName);
            var list = query.ToList();

            var listVM = new List<Data.ViewModel.CarPartsVM>();

            foreach(var x in list)
            {
                listVM.Add(new Data.ViewModel.CarPartsVM()
                {
                    Name=x.Name,
            
                    Price =x.Price,
                    Quality=x.Quality,
                    CategoryName=x.Category.CategoryName,
                    SubCategoryName=x.SubCategory.SubCategoryName,
                    CategoryID = x.CategoryID,
                    SubCategoryID = x.SubCategoryID,
                    CarPartID = x.CarPartID

                });
                
            }
            return listVM;
        }
        public override Data.ViewModel.CarPartsVM GetById(int id)
        {
            var entity = _context.Set<CarParts>().Include(p => p.Category).Include(p => p.SubCategory).Where(p => p.CarPartID == id).SingleOrDefault();

            var obj = new Data.ViewModel.CarPartsVM()
            {
                Name=entity.Name,
                Photo=entity.Photo,
                Quality=entity.Quality,
                Price=entity.Price,
                CategoryName=entity.Category.CategoryName,
                SubCategoryName=entity.SubCategory.SubCategoryName,
                CategoryID = entity.CategoryID,
                SubCategoryID = entity.SubCategoryID,
                CarPartID = entity.CarPartID
            };
            return obj;
        }
        public override Data.ViewModel.CarPartsVM Insert(CarPartsUpsertRequest request)
        {
            var entity = _mapper.Map<CarParts>(request);

            _context.Set<CarParts>().Add(entity);
            _context.SaveChanges();
            var obj = _context.CarParts.Where(p => p.CarPartID == entity.CarPartID).Include(p => p.Category).Include(p => p.SubCategory).SingleOrDefault();

            var vm = new Data.ViewModel.CarPartsVM()
            {
                Name=obj.Name,
                Photo=obj.Photo,
                Price=obj.Price,
                Quality=obj.Quality,
                SubCategoryName=obj.SubCategory.SubCategoryName,
                CategoryName=obj.Category.CategoryName,
                CategoryID=obj.CategoryID,
                SubCategoryID=obj.SubCategoryID,
                CarPartID=obj.CarPartID
            };
            return vm;
        }
        public override Data.ViewModel.CarPartsVM Update(int id, CarPartsUpsertRequest request)
        {
            var entity = _context.Set<CarParts>().Find(id);
            _context.Set<CarParts>().Attach(entity);
            _context.Set<CarParts>().Update(entity);

            _mapper.Map(request, entity);

            _context.SaveChanges();

            var obj = _context.CarParts.Where(p => p.CarPartID == entity.CarPartID).Include(p => p.Category).Include(p => p.SubCategory).SingleOrDefault();

            var vm = new Data.ViewModel.CarPartsVM()
            {
                Name = obj.Name,
                Photo = obj.Photo,
                Price = obj.Price,
                Quality = obj.Quality,
                SubCategoryName = obj.SubCategory.SubCategoryName,
                CategoryName = obj.Category.CategoryName,
                CategoryID = obj.CategoryID,
                SubCategoryID = obj.SubCategoryID,
                CarPartID = obj.CarPartID
            };
            return vm;
        }
    }
}

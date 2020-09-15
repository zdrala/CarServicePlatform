using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace CarService.WebAPI.Services
{
    public class RecommenderService : IRecommenderService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public RecommenderService(CarServiceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public CarServicesRecommenderModel Get(UserRecommendationRequest req)
        {
            var UserEntity = _context.Users.Find(req.UserID);

            var carServicesList = _context.CarServices.Include(c=>c.City).ToList();

            var ratingList = _context.Ratings.Include(r => r.User).ToList();

            float countPositiveRatings = 0;
            float countNegativeRatings = 0;


            CarServicesRecommenderModel model = new CarServicesRecommenderModel();
            model.listToRecommend = new List<Data.Model.CarService>();
            model.others= new List<Data.Model.CarService>();

            foreach (var carservice in carServicesList)
            {
                countPositiveRatings = 0;
                countNegativeRatings = 0;
                if (carservice.City.CityName == "Bugojno")
                {
                    foreach (var r in ratingList)
                    {
                      
                            if (carservice.CarServiceID == r.CarServiceID && r.User.CarBrandID == UserEntity.CarBrandID && r.UserID != UserEntity.UserID)
                            {
                                if (r.isLiked)
                                {
                                    countPositiveRatings++;
                                }
                                else
                                {
                                    countNegativeRatings++;
                                }
                            }
                           
                   
                    }

                    var total = countPositiveRatings + countNegativeRatings;
                    float avg = 0;
                    if (countPositiveRatings != 0)
                    {
                        avg = (float)(countPositiveRatings / total);
                    }
                    if (avg*5>2.5)
                    {
                     
                        model.listToRecommend.Add(new Data.Model.CarService()
                        {
                            CarServiceID = carservice.CarServiceID,
                            CarServiceName = carservice.CarServiceName,
                            CreatedDate = carservice.CreatedDate,
                            CityID = carservice.CityID,
                            Street = carservice.Street,
                            PhoneNumber = carservice.PhoneNumber,
                            Owner = carservice.Owner,
                            Photo = carservice.Photo,
                            NumberOfDislikes = carservice.NumberOfDislikes,
                            NumberOfLikes = carservice.NumberOfLikes,
                            UserID = carservice.UserID,
                            PositiveDifferent = countPositiveRatings - countNegativeRatings
                        });
                    }
                    else
                    {
                        model.others.Add(new Data.Model.CarService()
                        {
                            CarServiceID = carservice.CarServiceID,
                            CarServiceName = carservice.CarServiceName,
                            CreatedDate = carservice.CreatedDate,
                            CityID = carservice.CityID,
                            Street = carservice.Street,
                            PhoneNumber = carservice.PhoneNumber,
                            Owner = carservice.Owner,
                            Photo = carservice.Photo,
                            NumberOfDislikes = carservice.NumberOfDislikes,
                            NumberOfLikes = carservice.NumberOfLikes,
                            UserID = carservice.UserID,
                    
                        });
                    }
                }


            }
            model.listToRecommend=model.listToRecommend.OrderByDescending(r => r.PositiveDifferent).ToList();


            return model;
        }
    }
}

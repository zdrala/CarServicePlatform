using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Mappers
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Database.CarService,Data.Requests.CarServiceUpsertRequest>().ReverseMap();
            CreateMap<Database.CarService, Data.Model.CarService>();
            CreateMap<Database.Services, Data.Model.Services>();
            CreateMap<Database.Services, Data.Requests.ServicesInsertUpdateRequest>().ReverseMap();

            CreateMap<Database.CarPartCategory, Data.Model.CarPartCategory>();
            CreateMap<Database.CarPartSubCategory, Data.Model.CarPartSubCategory>();

            CreateMap<Database.CarPartSubCategory, Data.Model.CarPartSubCategory>();

            CreateMap<Database.CarParts, Data.Requests.CarPartsUpsertRequest>().ReverseMap();


            CreateMap<Database.Users, Data.Requests.UserInsertUpdateRequest>().ReverseMap();
            CreateMap<Database.Users, Data.Model.Users>();
            CreateMap<Database.Cities, Data.Model.Cities>();


            CreateMap<Database.Schedule, Data.Requests.ScheduleUpsertRequest>().ReverseMap();
            CreateMap<Database.Schedule, Data.Model.Schedule>();


            CreateMap<Database.Offers, Data.Model.Offer>();
            CreateMap<Database.Offers, Data.Requests.OfferInsertRequest>().ReverseMap();

            CreateMap<Database.Request, Data.Requests.RequestUpsert>().ReverseMap();


            CreateMap<Database.OfferItems, Data.Model.OfferItems>();
            CreateMap<Database.OfferItems, Data.Requests.OfferItemsInsertRequest>().ReverseMap();


            CreateMap<Database.Communications, Data.Requests.CommunicationUpsertRequest>().ReverseMap();


            CreateMap<Database.CarBrands, Data.Model.CarBrands>();
            CreateMap<Database.CarModels, Data.Model.CarModels>();

            CreateMap<Database.Ratings, Data.Model.Ratings>();
            CreateMap<Database.Ratings, Data.Requests.RatingInsertRequest>().ReverseMap();


            CreateMap<Database.Payments, Data.Model.Payments>();
            CreateMap<Database.Payments, Data.Requests.PaymentInsertRequest>().ReverseMap();

            CreateMap<Database.Ticket, Data.Model.Ticket>();
            CreateMap<Database.Ticket, Data.Requests.TicketInsertRequest>().ReverseMap();
        }
    }
}

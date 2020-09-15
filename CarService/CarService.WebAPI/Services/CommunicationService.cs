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
    public class CommunicationService : ICommunicationService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;

        public CommunicationService(CarServiceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Communication> Get(CommunicationsSearchRequest request)
        {
            var query = _context.Communications.Include(c=>c.User).AsQueryable();
            var list=new List<Database.Communications>();
            if (request.AdminSearch)
            {
                query = query.Where(c => c.CarServiceID == request.carServiceID && !c.isAnswered);
                list = query.OrderBy(c => c.DateOfMessage).ToList();
            }
            if(request.ClientSearch)
            {
                query = query.Where(c => c.CarServiceID == request.carServiceID && c.UserID==request.UserID );
                list = query.OrderByDescending(c => c.DateOfMessage).ToList();
            }

            var modelList = new List<Data.Model.Communication>();
            foreach(var x in list)
            {
                modelList.Add(new Data.Model.Communication()
                {
                    CommunicationID=x.CommunicationID,
                    DateOfMessage=x.DateOfMessage,
        
                    UserID=x.UserID,
                    UserNameLastName=x.User.FirstName+" "+x.User.LastName,
                    CarServiceID=x.CarServiceID,
                    Content=x.Content,
                    AnswerContent=x.AnswerContent,
                    isAnswered=x.isAnswered

                });
            }
            return modelList;
        }

        public Communication GetByID(int id)
        {
            var x = _context.Communications.Include(c => c.User).Where(c => c.CommunicationID == id).SingleOrDefault();
            var model = new Data.Model.Communication()
            {
                CommunicationID = x.CommunicationID,
                DateOfMessage = x.DateOfMessage,

                UserID = x.UserID,
                UserNameLastName = x.User.FirstName + " " + x.User.LastName,
                CarServiceID = x.CarServiceID,
                Content = x.Content,
                AnswerContent = x.AnswerContent,
                isAnswered = x.isAnswered
            };
            return model;
        }

        public Communication Insert(CommunicationUpsertRequest req)
        {
            var x = _mapper.Map<Database.Communications>(req);
            _context.Communications.Add(x);

            _context.SaveChanges();
            var model = new Data.Model.Communication()
            {
                CommunicationID = x.CommunicationID,
                DateOfMessage = x.DateOfMessage,

                UserID = x.UserID,
                UserNameLastName = x.User.FirstName + " " + x.User.LastName,
                CarServiceID = x.CarServiceID,
                Content = x.Content,
                AnswerContent = x.AnswerContent,
                isAnswered = x.isAnswered
            };
            return model;
        }

        public Communication Update(int id, CommunicationUpsertRequest req)
        {
            var x = _context.Communications.Include(c=>c.User).Where(c => c.CommunicationID == id).SingleOrDefault();
            _context.Communications.Attach(x);
            _context.Communications.Update(x);

            _mapper.Map(req, x);
            _context.SaveChanges();

            var model = new Data.Model.Communication()
            {
                CommunicationID = x.CommunicationID,
                DateOfMessage = x.DateOfMessage,

                UserID = x.UserID,
                UserNameLastName = x.User.FirstName + " " + x.User.LastName,
                CarServiceID = x.CarServiceID,
                Content = x.Content,
                AnswerContent = x.AnswerContent,
                isAnswered = x.isAnswered
            };
            return model;
        }
    }
}

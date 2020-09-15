using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarService.Data.Model;
using CarService.Data.Requests;
using CarService.WebAPI.Database;
using Microsoft.EntityFrameworkCore;

namespace CarService.WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly CarServiceContext _context;
        private readonly IMapper _mapper;
        public UserService(CarServiceContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Data.Model.Users Authenticate(string username, string pass)
        {
            var user = _context.Users.Include(u=>u.Role).FirstOrDefault(x => x.Username == username);

            if (user != null)
            {
                var newHash = GenerateHash(user.PasswordSalt, pass);

                if (newHash == user.PasswordHash)
                {
                    var model= _mapper.Map<Data.Model.Users>(user);
                    model.RoleName = user.Role.RoleName;
                    return model;
                }
            }
            return null;
        }

        public List<Data.Model.Users> Get(UserSearchRequest request)
        {
            var query = _context.Users.AsQueryable();

            if(!string.IsNullOrWhiteSpace(request.username))
            {
                query = query.Where(u => u.Username == request.username);
            }
            var list = query.ToList();
            return _mapper.Map<List<Data.Model.Users>>(list);
        }

     

        public Data.Model.Users GetById(int id)
        {
            var entity = _context.Users.Find(id);

            return _mapper.Map<Data.Model.Users>(entity);
        }
        
        public Data.Model.Users Insert(UserInsertUpdateRequest request)
        {
            var entity = _mapper.Map<Database.Users>(request);
            if(request.Username==null||request.Password==null||request.PasswordConfirmation==null)
            {
                throw new Exception("Username or Password or Password Confirmation is empty!");
            }

            if(request.Password!=request.PasswordConfirmation)
            {
                throw new Exception("Passwords are not matching");
            }

            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            entity.DateCreated = DateTime.Now;
            _context.Users.Add(entity);
            _context.SaveChanges();

            var obj = _context.Users.Include(u => u.Role).Where(u => u.UserID == entity.UserID).SingleOrDefault();

            var model = _mapper.Map<Data.Model.Users>(obj);
            model.RoleName = obj.Role.RoleName;
            return model;

        }
        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }
        public Data.Model.Users Update(int id, UserInsertUpdateRequest request)
        {
            var entity = _context.Users.Find(id);
            _context.Users.Attach(entity);
            _context.Users.Update(entity);

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Email = request.Email;
            entity.Username = request.Username;
            if(request.CityID>0)
            entity.CityID = request.CityID;

         if(request.CarBrandID!=null)
            entity.CarBrandID = request.CarBrandID;

         if(request.CarModelID!=null)
            entity.CarModelID = request.CarModelID;


            entity.DateOfBirth = request.DateOfBirth;
            if(!string.IsNullOrEmpty(request.Password))
            {
                entity.PasswordSalt = GenerateSalt();
                entity.PasswordHash = GenerateHash(entity.PasswordSalt, request.Password);
            }

            _context.SaveChanges();

            var obj = _context.Users.Include(u => u.Role).Where(u => u.UserID == entity.UserID).SingleOrDefault();

            var model = _mapper.Map<Data.Model.Users>(obj);
            model.RoleName = obj.Role.RoleName;
            return model;
        }
    }
}

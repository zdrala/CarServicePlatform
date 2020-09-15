using CarService.WebAPI.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI.Database
{
    public partial class CarServiceContext:DbContext
    {
        public CarServiceContext(DbContextOptions<CarServiceContext> x) : base(x)
        {

        }
   

        //public DbSet<Account> Accounts { get; set; }
        public DbSet<CarBrands> CarBrands { get; set; }
        public DbSet<CarModels> CarModels { get; set; }

        public DbSet<CarPartCategory> CarPartCategories { get; set; }
        public DbSet<CarParts> CarParts{ get; set; }
        public DbSet<CarPartSubCategory> CarPartSubCategories { get; set; }
        public DbSet<CarService> CarServices { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Communications> Communications { get; set; }

        public DbSet<OfferItems> OfferItems { get; set; }

        public DbSet<Offers> Offers { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<Ratings> Ratings { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<RequestServices> requestServices { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }

        public DbSet<Roles> Roles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<ScheduleStatus> ScheduleStatuses { get; set; }
        public DbSet<Services> Services { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Users> Users { get; set; }

        internal object Include(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //request statuses

            modelBuilder.Entity<RequestStatus>().HasData(new RequestStatus() { StatusID=1,statusName="Na čekanju"});
            modelBuilder.Entity<RequestStatus>().HasData(new RequestStatus() { StatusID = 2, statusName = "Odobren" });
            modelBuilder.Entity<RequestStatus>().HasData(new RequestStatus() { StatusID = 3, statusName = "Odbijen" });


            //Schedule statuses
            modelBuilder.Entity<ScheduleStatus>().HasData(new ScheduleStatus() { StatusID = 1, name = "U toku" });
            modelBuilder.Entity<ScheduleStatus>().HasData(new ScheduleStatus() { StatusID = 2, name = "Završen" });

            //Payment types
            modelBuilder.Entity<PaymentType>().HasData(new PaymentType() { PaymentTypeID = 1, PaymentName = "Plaćanje gotovinom" });
            modelBuilder.Entity<PaymentType>().HasData(new PaymentType() { PaymentTypeID = 2, PaymentName = "Plaćanje kreditnom karticom online" });
            //User roles
            modelBuilder.Entity<Roles>().HasData(new Roles()
            {
                RoleID = 1,
                RoleName = "Administrator"
            });

            modelBuilder.Entity<Roles>().HasData(new Roles()
            {
                RoleID = 2,
                RoleName = "User"
            });
            //Car brand and models
            modelBuilder.Entity<CarBrands>().HasData(new CarBrands()
            {
                CarBrandID = 1,
                BrandName = "Volkswagen"
            });
            modelBuilder.Entity<CarBrands>().HasData(new CarBrands()
            {
                CarBrandID = 2,
                BrandName = "Audi"
            });
            //car models
            modelBuilder.Entity<CarModels>().HasData(new CarModels()
            {
                CarModelID = 1,
                CarBrandID = 1,
                CarModelName = "Golf 5"

            });

            modelBuilder.Entity<CarModels>().HasData(new CarModels()
            {
                CarModelID = 2,
                CarBrandID = 1,
                CarModelName = "Passat 6"

            });

            modelBuilder.Entity<CarModels>().HasData(new CarModels()
            {
                CarModelID = 3,
                CarBrandID = 2,
                CarModelName = "Audi A4 2012"

            });
            //Cities
            modelBuilder.Entity<Cities>().HasData(new Cities()
            {
                CityID = 1,
                CityName = "Bugojno"

            });
            //Users
            Users u1 = new Users
            {
                UserID = 1,
                FirstName = "Mobile",
                LastName = "Korisnik",
                DateOfBirth = new DateTime(1998, 01, 13),
                DateCreated = DateTime.Now,
                CityID = 1,
                CarModelID = 2,
                CarBrandID = 1,
                Email = "mobile@gmail.com",
                PhoneNumber = "062/850-277",
                Username = "mobile",
                RoleID = 2
            };
            u1.PasswordSalt = HashGenerator.GenerateSalt();
            u1.PasswordHash = HashGenerator.GenerateHash(u1.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u1);
            Users u3 = new Users
            {
                UserID = 3,
                FirstName = "Mobile1",
                LastName = "Korisnik1",
                DateOfBirth = new DateTime(1998, 01, 13),
                DateCreated = DateTime.Now,
                CityID = 1,
                CarModelID = 2,
                CarBrandID = 1,
                Email = "mobile1@gmail.com",
                PhoneNumber = "062/850-277",
                Username = "mobile1",
                RoleID = 2
            };
            u3.PasswordSalt = HashGenerator.GenerateSalt();
            u3.PasswordHash = HashGenerator.GenerateHash(u3.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u3);
            Users u4 = new Users
            {
                UserID = 4,
                FirstName = "Mobile2",
                LastName = "Korisnik2",
                DateOfBirth = new DateTime(1998, 01, 13),
                DateCreated = DateTime.Now,
                CityID = 1,
                CarModelID = 1,
                CarBrandID = 1,
                Email = "mobile2@gmail.com",
                PhoneNumber = "062/850-277",
                Username = "mobile2",
                RoleID = 2
            };
            u4.PasswordSalt = HashGenerator.GenerateSalt();
            u4.PasswordHash = HashGenerator.GenerateHash(u4.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u4);
            Users u5 = new Users
            {
                UserID = 5,
                FirstName = "Mobile3",
                LastName = "Korisnik3",
                DateOfBirth = new DateTime(1998, 01, 13),
                DateCreated = DateTime.Now,
                CityID = 1,
                CarModelID = 1,
                CarBrandID = 1,
                Email = "mobile3@gmail.com",
                PhoneNumber = "062/850-277",
                Username = "mobile3",
                RoleID = 2
            };
            u5.PasswordSalt = HashGenerator.GenerateSalt();
            u5.PasswordHash = HashGenerator.GenerateHash(u5.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u5);

            Users u6 = new Users
            {
                UserID = 6,
                FirstName = "Mobile4",
                LastName = "Korisnik4",
                DateOfBirth = new DateTime(1998, 01, 13),
                DateCreated = DateTime.Now,
                CityID = 1,
                CarModelID = 2,
                CarBrandID = 1,
                Email = "mobile4@gmail.com",
                PhoneNumber = "062/850-277",
                Username = "mobile4",
                RoleID = 2
            };
            u6.PasswordSalt = HashGenerator.GenerateSalt();
            u6.PasswordHash = HashGenerator.GenerateHash(u6.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u6);


            //user admin
            Users u2 = new Users
            {
                UserID = 2,
                FirstName = "Desktop",
                LastName = "Korisnik",
                DateOfBirth = new DateTime(1995, 05, 23),
                DateCreated = DateTime.Now,
                CityID = 1,
                CarModelID = 2,
                CarBrandID = 1,
                Email = "desktop@gmail.com",
                PhoneNumber = "062/110-677",
                Username = "desktop",
                RoleID = 1
            };
            u2.PasswordSalt = HashGenerator.GenerateSalt();
            u2.PasswordHash = HashGenerator.GenerateHash(u2.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u2);

            Users u7 = new Users
            {
                UserID = 7,
                FirstName = "Desktop1",
                LastName = "Korisnik1",
                DateOfBirth = new DateTime(1995, 05, 23),
                DateCreated = DateTime.Now,
                CityID = 1,
                CarModelID = 3,
                CarBrandID = 2,
                Email = "desktop1@gmail.com",
                PhoneNumber = "062/110-677",
                Username = "desktop1",
                RoleID = 1
            };
            u7.PasswordSalt = HashGenerator.GenerateSalt();
            u7.PasswordHash = HashGenerator.GenerateHash(u7.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u7);
            Users u8 = new Users
            {
                UserID = 8,
                FirstName = "Desktop2",
                LastName = "Korisnik2",
                DateOfBirth = new DateTime(1995, 05, 23),
                DateCreated = DateTime.Now,
                CityID = 1,
                CarModelID = 3,
                CarBrandID = 2,
                Email = "desktop2@gmail.com",
                PhoneNumber = "062/110-677",
                Username = "desktop2",
                RoleID = 1
            };
            u8.PasswordSalt = HashGenerator.GenerateSalt();
            u8.PasswordHash = HashGenerator.GenerateHash(u8.PasswordSalt, "test");
            modelBuilder.Entity<Users>().HasData(u8);

            //Car service
            CarService cs1 = new CarService
            {
CarServiceID=1,
CarServiceName="Auto servis RS2",
CreatedDate=DateTime.Now,
CityID=1,
Street="Ulica seminarski",
PhoneNumber="062/110-677",
Owner="Desktop korisnik",
Photo= File.ReadAllBytes("img/carServicePhoto1.jpg"),
NumberOfLikes =0,
NumberOfDislikes=0,
UserID=2



            };
            modelBuilder.Entity<CarService>().HasData(cs1);

            CarService cs2 = new CarService
            {
                CarServiceID = 2,
                CarServiceName = "Auto servis FIT",
                CreatedDate = DateTime.Now,
                CityID = 1,
                Street = "Ulica 11",
                PhoneNumber = "062/110-677",
                Owner = "Desktop1 Korisnik1",
                Photo = File.ReadAllBytes("img/carServicePhoto2.jpg"),
                NumberOfLikes = 0,
                NumberOfDislikes = 0,
                UserID = 7



            };
            modelBuilder.Entity<CarService>().HasData(cs2);

            CarService cs3 = new CarService
            {
                CarServiceID = 3,
                CarServiceName = "Auto servis Ždralović",
                CreatedDate = DateTime.Now,
                CityID = 1,
                Street = "Ulica fit",
                PhoneNumber = "062/110-677",
                Owner = "Desktop2 Korisnik2",
                Photo = File.ReadAllBytes("img/carServicePhoto3.jpg"),
                NumberOfLikes = 0,
                NumberOfDislikes = 0,
                UserID = 8



            };
            modelBuilder.Entity<CarService>().HasData(cs3);
            //Services
            Services s1 = new Services {
            ServiceID=1,
            CarServiceID=1,
            ServiceName="Servisiranje kočionih diskova",
            ServicePrice=35,
            Description="Nudimo uslugu servisiranja  svega onoga sto je vezano za kočione diskove",
            ServiceTime="120"
            };
            modelBuilder.Entity<Services>().HasData(s1);

            Services s2 = new Services
            {
                ServiceID = 2,
                CarServiceID = 1,
                ServiceName = "Servisiranje vakumskih pumpi kočnica",
                ServicePrice = 25,
                Description = "Nudimo uslugu servisiranja  svega onoga sto je vezano za pumpe kočionih diskova",
                ServiceTime = "120"
            };
            modelBuilder.Entity<Services>().HasData(s2);

            //Services
            Services s3 = new Services
            {
                ServiceID = 3,
                CarServiceID = 1,
                ServiceName = "Servisiranje kvačila",
                ServicePrice = 55,
                Description = "Nudimo uslugu servisiranja pojedinacno ili u cijelini svega onoga sto je vezano za kvačila",
                ServiceTime = "220"
            };
            modelBuilder.Entity<Services>().HasData(s3);
            Services s4 = new Services
            {
                ServiceID = 4,
                CarServiceID = 1,
                ServiceName = "Servisiranje potisnih ležajeva",
                ServicePrice = 30,
                Description = "Nudimo uslugu servisiranja pojedinacno ili u cijelini svega onoga sto je vezano za potisne ležajeve kvačila",
                ServiceTime = "220"
            };
            modelBuilder.Entity<Services>().HasData(s4);

            Services s5 = new Services
            {
                ServiceID = 5,
                CarServiceID = 1,
                ServiceName = "Servisiranje letve volana",
                ServicePrice = 140,
                Description = "Nudimo uslugu servisiranja pojedinacno ili u cijelini svega onoga sto je vezano za letvu volana",
                ServiceTime = "200"
            };
            modelBuilder.Entity<Services>().HasData(s5);
            Services s6 = new Services
            {
                ServiceID = 6,
                CarServiceID = 1,
                ServiceName = "Servisiranje servo pumpe",
                ServicePrice = 60,
                Description = "Nudimo uslugu servisiranja pojedinacno ili u cijelini svega onoga sto je vezano za servo pumpe upravljača",
                ServiceTime = "270"
            };
            modelBuilder.Entity<Services>().HasData(s6);
            Services s7 = new Services
            {
                ServiceID = 7,
                CarServiceID = 2,
                ServiceName = "Servisiranje servo pumpe",
                ServicePrice = 60,
                Description = "Nudimo uslugu servisiranja pojedinacno ili u cijelini svega onoga sto je vezano za servo pumpe upravljača",
                ServiceTime = "270"
            };
            modelBuilder.Entity<Services>().HasData(s7);
            Services s8 = new Services
            {
                ServiceID = 8,
                CarServiceID = 3,
                ServiceName = "Servisiranje servo pumpe",
                ServicePrice = 60,
                Description = "Nudimo uslugu servisiranja pojedinacno ili u cijelini svega onoga sto je vezano za servo pumpe upravljača",
                ServiceTime = "270"
            };
            modelBuilder.Entity<Services>().HasData(s8);
            //CarParts categories and sub categories
            CarPartCategory cpc1 = new CarPartCategory {CategoryID=1,CategoryName="Kočioni sistemi"};
            CarPartCategory cpc2 = new CarPartCategory { CategoryID = 2, CategoryName = "Kvačila" };
            CarPartCategory cpc3 = new CarPartCategory { CategoryID = 3, CategoryName = "Prijenosnik upravljača" };
            modelBuilder.Entity<CarPartCategory>().HasData(cpc1);
            modelBuilder.Entity<CarPartCategory>().HasData(cpc2);
            modelBuilder.Entity<CarPartCategory>().HasData(cpc3);

            CarPartSubCategory cps1 = new CarPartSubCategory {SubCategoryID=1, CategoryID = 1, SubCategoryName = "Diskovi za kočnice" };
            CarPartSubCategory cps2 = new CarPartSubCategory { SubCategoryID = 2, CategoryID = 1, SubCategoryName = "Vakumske pumpe" };
            CarPartSubCategory cps3 = new CarPartSubCategory { SubCategoryID = 3, CategoryID = 2, SubCategoryName = "Komplet kvačila" };
            CarPartSubCategory cps4 = new CarPartSubCategory { SubCategoryID = 4, CategoryID = 2, SubCategoryName = "Potisni ležajevi" };
            CarPartSubCategory cps5 = new CarPartSubCategory { SubCategoryID = 5, CategoryID = 3, SubCategoryName = "Letva volana" };
            CarPartSubCategory cps6 = new CarPartSubCategory { SubCategoryID = 6, CategoryID = 3, SubCategoryName = "servo pumpa" };
            modelBuilder.Entity<CarPartSubCategory>().HasData(cps1);
            modelBuilder.Entity<CarPartSubCategory>().HasData(cps2);
            modelBuilder.Entity<CarPartSubCategory>().HasData(cps3);
            modelBuilder.Entity<CarPartSubCategory>().HasData(cps4);
            modelBuilder.Entity<CarPartSubCategory>().HasData(cps5);
            modelBuilder.Entity<CarPartSubCategory>().HasData(cps6);
            //carparts
            byte[] photoPart1 = File.ReadAllBytes("img/brakedisc.jpg");
            CarParts cp1 = new CarParts {
                CarPartID = 1,
                Name = "Disk za kočnice",
                Photo=photoPart1,
            Price=100,
                Quality="Quality I",
                CategoryID=1,
                SubCategoryID=1,
                CarServiceID=1};

       

            CarParts cp2 = new CarParts
            {
                CarPartID = 2,
                Name = "Disk za kočnice",
                Photo = photoPart1,
                Price = 150,
                Quality = "Quality II",
                CategoryID = 1,
                SubCategoryID = 1,
                CarServiceID = 1
            };
            CarParts cp3 = new CarParts
            {
                CarPartID = 3,
                Name = "Disk za kočnice",
                Photo = photoPart1,
                Price = 200,
                Quality = "Quality III",
                CategoryID = 1,
                SubCategoryID = 1,
                CarServiceID = 1
            };
            modelBuilder.Entity<CarParts>().HasData(cp1);
            modelBuilder.Entity<CarParts>().HasData(cp2);
            modelBuilder.Entity<CarParts>().HasData(cp3);
            byte[] photoPart2 = File.ReadAllBytes("img/vakumskepumpe.jpg");
            CarParts cp4 = new CarParts
            {
                CarPartID = 4,
                Name = "vakumske pumpe",
                Photo= photoPart2,
                Price = 200,
                Quality = "Quality I",
                CategoryID = 1,
                SubCategoryID = 2,
                CarServiceID = 1
            };
            CarParts cp5 = new CarParts
            {
                CarPartID = 5,
                Name = "vakumske pumpe",
                Photo = photoPart2,
                Price = 300,
                Quality = "Quality II",
                CategoryID = 1,
                SubCategoryID = 2,
                CarServiceID = 1
            };
            CarParts cp6 = new CarParts
            {
                CarPartID = 6,
                Name = "vakumske pumpe",
                Photo = photoPart2,
                Price = 400,
                Quality = "Quality III",
                CategoryID = 1,
                SubCategoryID = 2,
                CarServiceID = 1
            };
            modelBuilder.Entity<CarParts>().HasData(cp4);
            modelBuilder.Entity<CarParts>().HasData(cp5);
            modelBuilder.Entity<CarParts>().HasData(cp6);
            byte[] photoPart3 = File.ReadAllBytes("img/kvachilo.png");
            CarParts cp7 = new CarParts
            {
                CarPartID = 7,
                Name = "Kvaličo",
                Photo= photoPart3,
                Price = 135,
                Quality = "Quality I",
                CategoryID = 2,
                SubCategoryID = 3,
                CarServiceID = 1
            };
            CarParts cp8 = new CarParts
            {
                CarPartID = 8,
                Name = "Kvačilo",
                Photo = photoPart3,
                Price = 202,
                Quality = "Quality II",
                CategoryID = 2,
                SubCategoryID = 3,
                CarServiceID = 1
            };
            CarParts cp9 = new CarParts
            {
                CarPartID = 9,
                Name = "Kvačilo",
                Photo = photoPart3,
                Price = 270,
                Quality = "Quality III",
                CategoryID = 2,
                SubCategoryID = 3,
                CarServiceID = 1
            };
            modelBuilder.Entity<CarParts>().HasData(cp7);
            modelBuilder.Entity<CarParts>().HasData(cp8);
            modelBuilder.Entity<CarParts>().HasData(cp9);
            byte[] photoPart4 = File.ReadAllBytes("img/potisnilezajevi.jpeg");
            CarParts cp10 = new CarParts
            {
                CarPartID = 10,
                Name = "Potisni ležaj",
                Photo = photoPart4,
                Price = 65,
                Quality = "Quality I",
                CategoryID = 2,
                SubCategoryID = 4,
                CarServiceID = 1
            };
            CarParts cp11 = new CarParts
            {
                CarPartID = 11,
                Name = "Potisni ležaj",
                Photo= photoPart4,
                Price = 97,
                Quality = "Quality II",
                CategoryID = 2,
                SubCategoryID = 4,
                CarServiceID = 1
            };
            CarParts cp12 = new CarParts
            {
                CarPartID = 12,
                Name = "Potisni ležaj",
                Photo = photoPart4,
                Price = 130,
                Quality = "Quality III",
                CategoryID = 2,
                SubCategoryID = 4,
                CarServiceID = 1
            };
            modelBuilder.Entity<CarParts>().HasData(cp10);
            modelBuilder.Entity<CarParts>().HasData(cp11);
            modelBuilder.Entity<CarParts>().HasData(cp12);
            byte[] photoPart5 = File.ReadAllBytes("img/lvolana.jpeg");
            CarParts cp13 = new CarParts
            {
                CarPartID = 13,
                Name = "Letva volana",
                Photo= photoPart5,
                Price = 350,
                Quality = "Quality I",
                CategoryID = 3,
                SubCategoryID = 5,
                CarServiceID = 1
            };
            CarParts cp14 = new CarParts
            {
                CarPartID = 14,
                Name = "Letva volana",
                Photo = photoPart5,
                Price = 525,
                Quality = "Quality II",
                CategoryID = 3,
                SubCategoryID = 5,
                CarServiceID = 1
            };
            CarParts cp15 = new CarParts
            {
                CarPartID = 15,
                Name = "Letva volana",
                Photo = photoPart5,
                Price = 700,
                Quality = "Quality III",
                CategoryID = 3,
                SubCategoryID = 5,
                CarServiceID = 1
            };
            modelBuilder.Entity<CarParts>().HasData(cp13);
            modelBuilder.Entity<CarParts>().HasData(cp14);
            modelBuilder.Entity<CarParts>().HasData(cp15);
            byte[] photoPart6 = File.ReadAllBytes("img/spumpa.jpeg");
            CarParts cp16 = new CarParts
            {
                CarPartID = 16,
                Name = "Servo pumpa",
                Photo= photoPart6,
                Price = 150,
                Quality = "Quality I",
                CategoryID = 3,
                SubCategoryID = 6,
                CarServiceID = 1
            };
            CarParts cp17 = new CarParts
            {
                CarPartID = 17,
                Name = "Servo pumpa",
                Photo = photoPart6,
                Price = 225,
                Quality = "Quality II",
                CategoryID = 3,
                SubCategoryID = 6,
                CarServiceID = 1
            };
            CarParts cp18 = new CarParts
            {
                CarPartID = 18,
                Name = "Servo pumpa",
                Photo = photoPart6,
                Price = 300,
                Quality = "Quality III",
                CategoryID = 3,
                SubCategoryID = 6,
                CarServiceID = 1
            };
            modelBuilder.Entity<CarParts>().HasData(cp16);
            modelBuilder.Entity<CarParts>().HasData(cp17);
            modelBuilder.Entity<CarParts>().HasData(cp18);

            //Requests and schedules

            modelBuilder.Entity<Request>().HasData(new Request()
            {
                RequestID=1,
                CarServiceID = 1,
                DateOfRequest = DateTime.Now,
                RequestStatusID=1,
                UserID=1               
            }) ;
            modelBuilder.Entity<RequestServices>().HasData(new RequestServices() {RequestServiceID=1,RequestID=1,ServiceID=1 });
            modelBuilder.Entity<RequestServices>().HasData(new RequestServices() { RequestServiceID = 2, RequestID = 1, ServiceID = 3 });
            modelBuilder.Entity<RequestServices>().HasData(new RequestServices() { RequestServiceID = 3, RequestID = 1, ServiceID = 5 });
            modelBuilder.Entity<Request>().HasData(new Request()
            {
                RequestID = 2,
                CarServiceID = 1,
                DateOfRequest = DateTime.Now,
                RequestStatusID = 2,
                UserID = 4
            });
            modelBuilder.Entity<RequestServices>().HasData(new RequestServices() { RequestServiceID = 4, RequestID = 2, ServiceID = 1 });
            modelBuilder.Entity<RequestServices>().HasData(new RequestServices() { RequestServiceID = 5, RequestID = 2, ServiceID = 4 });
            modelBuilder.Entity<RequestServices>().HasData(new RequestServices() { RequestServiceID = 6, RequestID = 2, ServiceID = 6 });
            modelBuilder.Entity<Schedule>().HasData(new Schedule()
            {
                ScheduleID = 1,
                DateofSchedule = new DateTime(2020, 09, 18),
                isPaid=false,
                RequestID=2,
                ScheduleStatusID=2,
                totalPrice=125

            }); 
            //rating za prvi car service
            modelBuilder.Entity<Ratings>().HasData(new Ratings() {
                RatingID=1,
            UserID=3,
            CarServiceID=1,
            isLiked=true,
            isDisliked=false,
            ScheduleID=1

            
            });
            modelBuilder.Entity<Ratings>().HasData(new Ratings()
            {
                RatingID = 2,
                UserID = 4,
                CarServiceID = 1,
                isLiked = true,
                isDisliked = false,
                ScheduleID = 1


            });
            modelBuilder.Entity<Ratings>().HasData(new Ratings()
            {
                RatingID = 3,
                UserID = 5,
                CarServiceID = 1,
                isLiked = true,
                isDisliked = false,
                ScheduleID = 1


            });
            //rating za drugi car service
            modelBuilder.Entity<Ratings>().HasData(new Ratings()
            {
                RatingID = 4,
                UserID = 3,
                CarServiceID = 2,
                isLiked = true,
                isDisliked = false,
                ScheduleID = 1


            });
            modelBuilder.Entity<Ratings>().HasData(new Ratings()
            {
                RatingID = 5,
                UserID = 4,
                CarServiceID = 2,
                isLiked = true,
                isDisliked = false,
                ScheduleID = 1


            });
            modelBuilder.Entity<Ratings>().HasData(new Ratings()
            {
                RatingID = 6,
                UserID = 5,
                CarServiceID = 2,
                isLiked = true,
                isDisliked = false,
                ScheduleID = 1


            });
            modelBuilder.Entity<Ratings>().HasData(new Ratings()
            {
                RatingID =7,
                UserID = 6,
                CarServiceID = 2,
                isLiked = false,
                isDisliked = true,
                ScheduleID = 1


            });
            //Communication
            modelBuilder.Entity<Communications>().HasData(new Communications() { 
                CommunicationID=1,
            UserID=1,
            CarServiceID=1,
            DateOfMessage=DateTime.Now,
            Content="Pitanje Broj 1",
            AnswerContent="Odgovr na pitanje Broj 1",
            isAnswered=true


            
            });
            modelBuilder.Entity<Communications>().HasData(new Communications()
            {
                CommunicationID = 2,
                UserID = 1,
                CarServiceID = 1,
                DateOfMessage = DateTime.Now,
                Content = "Pitanje Broj 2",
                AnswerContent = null,
                isAnswered = false



            });

        }








    }
}

using CarService.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.WebAPI.Helper;

namespace CarService.WebAPI.Database
{
    public partial class CarServiceContext
    {
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //User roles
        //    modelBuilder.Entity<Roles>().HasData(new Roles()
        //    {
        //        RoleID = 1,
        //        RoleName = "Administrator"
        //    });

        //    modelBuilder.Entity<Roles>().HasData(new Roles()
        //    {
        //        RoleID = 2,
        //        RoleName = "User"
        //    });
        //    //Car brand and models
        //    modelBuilder.Entity<CarBrands>().HasData(new CarBrands()
        //    {
        //        CarBrandID = 1,
        //        BrandName = "Volkswagen"
        //    });
        //    modelBuilder.Entity<CarBrands>().HasData(new CarBrands()
        //    {
        //        CarBrandID = 2,
        //        BrandName = "Audi"
        //    });
        //    //car models
        //    modelBuilder.Entity<CarModels>().HasData(new CarModels()
        //    {
        //        CarModelID = 1,
        //        CarBrandID = 1,
        //        CarModelName = "Golf 5"

        //    });

        //    modelBuilder.Entity<CarModels>().HasData(new CarModels()
        //    {
        //        CarModelID = 2,
        //        CarBrandID = 1,
        //        CarModelName = "Passat 6"

        //    });

        //    modelBuilder.Entity<CarModels>().HasData(new CarModels()
        //    {
        //        CarModelID = 3,
        //        CarBrandID = 2,
        //        CarModelName = "Audi A4 2012"

        //    });
        //    //Cities
        //    modelBuilder.Entity<Cities>().HasData(new Cities()
        //    {
        //        CityID = 1,
        //        CityName = "Bugojno"

        //    });
        //    //Users
        //    Users u1 = new Users
        //    {
        //        UserID = 1,
        //        FirstName = "Ahmed",
        //        LastName = "Ždralović",
        //        DateOfBirth = new DateTime(1998, 01, 13),
        //        DateCreated = DateTime.Now,
        //        CityID = 1,
        //        CarModelID = 2,
        //        CarBrandID = 1,
        //        Email = "esltnk@gmail.com",
        //        PhoneNumber = "062/850-277",
        //        Username = "aaa",
        //        RoleID = 2
        //    };
        //    u1.PasswordSalt = HashGenerator.GenerateSalt();
        //    u1.PasswordHash = HashGenerator.GenerateHash(u1.PasswordSalt, "aaa");
        //    modelBuilder.Entity<Users>().HasData(u1); ;

        //}



    }
}

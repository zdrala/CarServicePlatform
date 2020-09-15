using CarService.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.WebAPI
{
    public class SetupService
    {
        public static void Init(CarServiceContext context)
        {
            context.Database.Migrate();

        }
    }
}

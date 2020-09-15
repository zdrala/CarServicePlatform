using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.WebAPI.Database;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CarService.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using CarService.WebAPI.Security;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.Swagger;


namespace CarService.WebAPI
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddDbContext<CarServiceContext>(x => x.UseSqlServer(Configuration.GetConnectionString("localDB")));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddAuthentication("BasicAuthentication")
                        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<ICarService, Services.CarService>();
            services.AddScoped<IServices, Services.Services>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICitiesService, CitiesService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IOfferItems, OfferItemsService>();
            services.AddScoped<ICommunicationService, CommunicationService>();
            services.AddScoped<ICompletedServicesByDateService, CountCompletedServicesByDateService>();
            services.AddScoped<IEarningsOfCompletedServicesByDate, EarningsOfCompletedServicesByDateService>();
            services.AddScoped<ICarBrandsService, CarBrandService>();
            services.AddScoped<ICarModelsService, CarModelsService>();
            services.AddScoped<IOfferItemsByClientService, OfferItemsByClientService>();
            services.AddScoped<IRequestServiceByClientService, RequestServiceByClientService>();
            services.AddScoped<IRatingsService, RatingsService>();
            services.AddScoped<IScheduleSecondService, ScheduleSecondService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IRecommenderService, RecommenderService>();

            services.AddScoped<IBaseService<Data.Model.CarPartCategory,object>,BaseService<Data.Model.CarPartCategory,object,CarPartCategory>>();
            services.AddScoped<IBaseService<Data.Model.Cities, object>, BaseService<Data.Model.Cities, object, Cities>>();
            services.AddScoped<IBaseService<Data.Model.CarPartSubCategory, Data.Requests.CarPartsSearchRequest>, PartsSubCategoryService>();

            services.AddScoped<ICRUDService<Data.ViewModel.CarPartsVM, Data.Requests.CarPartsSearchRequest,Data.Requests.CarPartsUpsertRequest,Data.Requests.CarPartsUpsertRequest>, CarPartsService>();
            services.AddScoped<ICRUDService<Data.ViewModel.CarPartsVM, Data.Requests.CarPartsSearchRequest, Data.Requests.CarPartsUpsertRequest, Data.Requests.CarPartsUpsertRequest>, CarPartsService>();

          

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using AutoMapper;
using Calendar.Dal;
using Calendar.Dal.Dto;
using Calendar.Dal.Interface;
using Calendar.Services.Impl;
using Calendar.Services.Interface;
using Calendar.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Services
{
    public class Registration
    {/// <summary>
     /// 
     /// </summary>
     /// <param name="services"></param>
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMonthService, MonthService>();

            services.AddScoped<IAppointmentService, AppointmentService>();

            Register.ConfigureServices(services);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void InitialiseData(IApplicationBuilder app)
        {
            var scopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var dbInitializer = scope.ServiceProvider.GetService<IDbInitializer>();
                dbInitializer.Initialize();
                dbInitializer.SeedData();
            }
        }
       
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<AppointmentViewModel, Appointment>();
            CreateMap<Appointment, AppointmentViewModel>().ForMember
                (x=>x.Attendee,m=>m.MapFrom(u=>u.Attendees_AppointmentId));

            CreateMap<Month, MonthViewModel>();
            CreateMap<MonthViewModel, Month>();

            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();

            CreateMap<Attendee, AttendeeViewModel>();
            CreateMap<AttendeeViewModel, Attendee>();
        }
    }
}

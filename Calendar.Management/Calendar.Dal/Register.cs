using Calendar.Dal.Impl;
using Calendar.Dal.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Dal
{
    public class Register
    {
        public static void ConfigureServices(IServiceCollection services)
        {
           services.AddDbContext<CalendarDbContext>(opt =>
                                                   opt.UseInMemoryDatabase("CalendarManagement"));
    
            services.AddScoped<IMonthRepository, MonthRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IDbInitializer, DbInitializer>();
        }
        
    }

    
}

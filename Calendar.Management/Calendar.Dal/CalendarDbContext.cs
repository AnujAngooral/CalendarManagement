using Calendar.Dal.DbConfig;
using Calendar.Dal.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Dal
{
    public class CalendarDbContext : DbContext
    {
        public CalendarDbContext(DbContextOptions<CalendarDbContext> options)
                 : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            //InitialiseUser(modelBuilder);
            //InitialiseMonth(modelBuilder);
            //InitialiseAppointment(modelBuilder);
            //InitialiseAttendee(modelBuilder);
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            //modelBuilder.ApplyConfiguration(new MonthConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());

           
        }
        
        
      
        
   
        

        public DbSet<Appointment> Appointments { get; set; } // Appointment
        public DbSet<Month> Months { get; set; } // Month
        public DbSet<User> Users { get; set; } // User
        public DbSet<Attendee> Attendees { get; set; } // Attendees
    }
}

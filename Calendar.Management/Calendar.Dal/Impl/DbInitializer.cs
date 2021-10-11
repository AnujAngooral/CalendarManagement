using Calendar.Dal.Dto;
using Calendar.Dal.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calendar.Dal.Impl
{
    class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }
        public void Initialize()
        {
            //using (var serviceScope = _scopeFactory.CreateScope())
            //{
            //    using (var context = serviceScope.ServiceProvider.GetService<CalendarDbContext>())
            //    {

            //    }
            //}
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<CalendarDbContext>())
                {
                    if (!context.Months.Any())
                    {
                        InitialiseMonth(context);
                    }
                    if (!context.Users.Any())
                    {
                        InitialiseUser(context);
                    }
                    if (!context.Appointments.Any())
                    {
                        InitialiseAppointment(context);
                    }
                    if (!context.Attendees.Any())
                    {
                        InitialiseAttendee(context);
                    }

                    context.SaveChanges();
                }
            }
        }
        static void InitialiseMonth(CalendarDbContext context)
        {
            List<string> str = new List<string>() {"Jan", "Feb","March","April","May","June","July","Aug",
                "Sep","Oct","Nov","Dec"};
            foreach (var item in str)
            {
                context.Months.AddAsync(new Month() { Name = item });
            }

        }
        static void InitialiseUser(CalendarDbContext context)
        {
            context.Users.Add(new User
            { Id = 1, UserName = "Anuj Angooral", FirstName = "Anuj", LastName = "Angooral" });

            context.Users.Add(new User
            { Id = 2, UserName = "Ankita Sharma", FirstName = "Ankita", LastName = "Sharma" });

            context.Users.Add(new User
            { Id = 3, UserName = "Varun Angooral", FirstName = "Varun", LastName = "Angooral" });
        }

        private static void InitialiseAppointment(CalendarDbContext context)
        {
            context.Appointments.Add(new Appointment
            {
                Date = new DateTime(2021, 1, 2, 2, 2, 2),
                Description = "Project Meeting",
                UserId = 1,
                MonthId = 1,

            });



            context.Appointments.Add(new Appointment
            {
                Date = new DateTime(2021, 1, 2, 3, 2, 2),
                Description = "Daily Standup",
                UserId = 1,
                MonthId = 1
            });
            context.Appointments.Add(new Appointment
            {
                Date = new DateTime(2021, 1, 3, 3, 4, 8),
                Description = "Lunch Time",
                UserId = 1,
                MonthId = 1
            });
            context.Appointments.Add(new Appointment
            {
                Date = new DateTime(2021, 1, 4, 6, 2, 4),
                Description = "Evening Snacks",
                UserId = 1,
                MonthId = 1
            });

            context.Appointments.Add(new Appointment
            {

                Date = new DateTime(2021, 2, 1, 6, 2, 4),
                Description = "Lunch with Joe",
                UserId = 1,
                MonthId = 2
            });
            context.Appointments.Add(new Appointment
            {
                Date = new DateTime(2021, 2, 3, 6, 2, 4),
                Description = "Evening Snacks",
                UserId = 1,
                MonthId = 2
            });
            context.Appointments.Add(new Appointment
            {

                Date = new DateTime(2021, 3, 4, 6, 2, 4),
                Description = "March meeting with team",
                UserId = 2,
                MonthId = 3
            });
            context.Appointments.Add(new Appointment
            {

                Date = new DateTime(2021, 4, 4, 6, 2, 4),
                Description = "Team meeting",
                UserId = 2,
                MonthId = 4
            });
        }

        private static void InitialiseAttendee(CalendarDbContext context)
        {
            context.Attendees.Add(new Attendee
            {

                AppointmentId = 1,
                UserId = 2
            });
            context.Attendees.Add(new Attendee
            {

                AppointmentId = 1,
                UserId = 3
            });

            context.Attendees.Add(new Attendee
            {

                AppointmentId = 2,
                UserId = 1
            });
            context.Attendees.Add(new Attendee
            {

                AppointmentId = 2,
                UserId = 2
            });

            context.Attendees.Add(new Attendee
            {

                AppointmentId = 3,
                UserId = 2
            });
            context.Attendees.Add(new Attendee
            {

                AppointmentId = 3,
                UserId = 3
            });

            context.Attendees.Add(new Attendee
            {
                AppointmentId = 4,
                UserId = 2
            });
            context.Attendees.Add(new Attendee
            {

                AppointmentId = 4,
                UserId = 3
            });

            context.Attendees.Add(new Attendee
            {
                AppointmentId = 5,
                UserId = 2
            });
            context.Attendees.Add(new Attendee
            {

                AppointmentId = 5,
                UserId = 3
            });

            context.Attendees.Add(new Attendee
            {
                AppointmentId = 6,
                UserId = 2
            });
            context.Attendees.Add(new Attendee
            {

                AppointmentId = 6,
                UserId = 3
            });

            context.Attendees.Add(new Attendee
            {
                AppointmentId = 7,
                UserId = 2
            });
            context.Attendees.Add(new Attendee
            {

                AppointmentId = 7,
                UserId = 3
            });

            context.Attendees.Add(new Attendee
            {
                AppointmentId = 8,
                UserId = 2
            });
            context.Attendees.Add(new Attendee
            {

                AppointmentId = 8,
                UserId = 3
            });
        }
    }
}

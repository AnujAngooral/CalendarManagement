using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; } // Id (Primary key)
        public string UserName { get; set; } // UserName (length: 250)
        public string FirstName { get; set; } // FirstName (length: 150)
        public string LastName { get; set; } // LastName (length: 150)

        // Reverse navigation

        /// <summary>
        /// Child Appointments where [Appointment].[Organizer] point to this entity (FK_Appointment_User)
        /// </summary>
        public virtual ICollection<AppointmentViewModel> Appointments { get; set; } // Appointment.FK_Appointment_User

        /// <summary>
        /// Child Attendees where [Attendees].[Attendee] point to this entity (FK_Attendees_User)
        /// </summary>
        public virtual ICollection<AttendeeViewModel> Attendees { get; set; } // Attendees.FK_Attendees_User

        public UserViewModel()
        {
            Appointments = new List<AppointmentViewModel>();
            Attendees = new List<AttendeeViewModel>();
        }
    }
}

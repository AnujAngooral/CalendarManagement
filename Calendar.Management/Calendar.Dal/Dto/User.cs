using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Dal.Dto
{
    public class User
    {
        public int Id { get; set; } // Id (Primary key)
        public string UserName { get; set; } // UserName (length: 250)
        public string FirstName { get; set; } // FirstName (length: 150)
        public string LastName { get; set; } // LastName (length: 150)

        // Reverse navigation

        /// <summary>
        /// Child Appointments where [Appointment].[Organizer] point to this entity (FK_Appointment_User)
        /// </summary>
     //   public virtual ICollection<Appointment> Appointments { get; set; } // Appointment.FK_Appointment_User

        /// <summary>
        /// Child Attendees where [Attendees].[Attendee] point to this entity (FK_Attendees_User)
        /// </summary>
     //   public virtual ICollection<Attendee> Attendees { get; set; } // Attendees.FK_Attendees_User

        public User()
        {
          //  Appointments = new List<Appointment>();
          //  Attendees = new List<Attendee>();
        }
    }
}

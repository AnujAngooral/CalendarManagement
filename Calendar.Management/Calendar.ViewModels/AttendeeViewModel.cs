using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.ViewModels
{
    public class AttendeeViewModel
    {
       // public int? AppointmentId { get; set; } // AppointmentId
        //public int? UserId { get; set; } // UserId
     //   public int Id { get; set; } // Id (Primary key)

        // Foreign keys

        /// <summary>
        /// Parent Appointment pointed by [Attendees].([AppointmentId]) (FK_Attendees_Appointment)
        /// </summary>
     //   public virtual AppointmentViewModel Appointment { get; set; } // FK_Attendees_Appointment

        /// <summary>
        /// Parent User pointed by [Attendees].([UserId]) (FK_Attendees_User)
        /// </summary>
        public virtual UserViewModel User { get; set; } // FK_Attendees_User
    }
}

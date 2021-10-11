using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Dal.Dto
{
    public class Appointment
    {
        public int Id { get; set; } // Id (Primary key)
        public DateTime? Date { get; set; } // Date
        public string Description { get; set; } // Description (length: 250)
        public DateTime? CreatedAt { get; set; } // CreatedAt
        public int? UserId { get; set; } // Organizer
        public int? Attendees { get; set; } // Attendees
        public int? MonthId { get; set; } // MonthId

        // Reverse navigation

        /// <summary>
        /// Child Attendees where [Attendees].[AppointmentId] point to this entity (FK_Attendees_Appointment)
        /// </summary>
        public virtual ICollection<Attendee> Attendees_AppointmentId { get; set; } // Attendees.FK_Attendees_Appointment

        // Foreign keys

        /// <summary>
        /// Parent Month pointed by [Appointment].([MonthId]) (FK_Appointment_Appointment)
        /// </summary>
        public virtual Month Month { get; set; } // FK_Appointment_Appointment

        /// <summary>
        /// Parent User pointed by [Appointment].([Organizer]) (FK_Appointment_User)
        /// </summary>
        public virtual User User { get; set; } // FK_Appointment_User

        public Appointment()
        {
            Attendees_AppointmentId = new List<Attendee>();
        }
    }
}

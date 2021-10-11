using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Dal.Dto
{
    public class Month
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 150)

        // Reverse navigation

        /// <summary>
        /// Child Appointments where [Appointment].[MonthId] point to this entity (FK_Appointment_Appointment)
        /// </summary>
        public virtual ICollection<Appointment> Appointments { get; set; } // Appointment.FK_Appointment_Appointment

        public Month()
        {
            Appointments = new List<Appointment>();
        }
    }
}

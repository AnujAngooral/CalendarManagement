using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar.Dal.Dto
{
    public class Meeting
    {
        public long Id { get; set; }
        public DateTime Date {get;set;}
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public User Organizer { get; set; }

        public ICollection<User> Attendees { get; set; }
    }
}

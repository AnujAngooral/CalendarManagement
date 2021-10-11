using Calendar.Dal.Dto;
using Calendar.Dal.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Dal.Impl
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        CalendarDbContext _context;
        public AppointmentRepository(CalendarDbContext context) : base(context)
        {
            _context = context;
        }
        public void Dispose()
        {

        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByMonth(int monthId)
        {
            return await _context.Appointments.Where(x => x.MonthId == monthId)
                  .Include(x => x.User)
                  .Include(x => x.Attendees_AppointmentId)
                  .ThenInclude(x => x.User).ToListAsync();
        }
    }
}

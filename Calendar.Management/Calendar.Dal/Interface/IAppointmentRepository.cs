using Calendar.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Dal.Interface
{
    public interface IAppointmentRepository : IRepository<Appointment>, IDisposable
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByMonth(int monthId);
    }
}

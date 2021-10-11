using Calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Services.Interface
{
   public interface IAppointmentService
    {
        Task<(bool IsSuccess, IEnumerable<AppointmentViewModel> Appointments, string ErrorMessage)> GetByMonthIdAsync(int monthId);
        
    }
}

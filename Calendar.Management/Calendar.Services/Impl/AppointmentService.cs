using AutoMapper;
using Calendar.Dal.Interface;
using Calendar.Services.Interface;
using Calendar.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Services.Impl
{
    public class AppointmentService : IAppointmentService
    {
        readonly IAppointmentRepository _appointmentRepository;

        private readonly IMapper _mapper;
        private readonly ILogger<AppointmentService> _logger;

        /// <summary>
        /// Initialise the appointment service with appointment repo, mapper and logger
        /// These paramters are initialise through the DI
        /// </summary>
        /// <param name="appointmentRepository">this repo is used to intract with database and insert, fetch
        /// appointment related things</param>
        /// <param name="mapper">mapper is used to convert dto to viewmodel and vice vesa</param>
        /// <param name="logger">logger is used to log messages</param>
        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper, ILogger<AppointmentService> logger)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// This method takes the month id and returns the collection of appointments.
        /// </summary>
        /// <param name="monthId">Month id for which you want to get appointments</param>
        /// <returns>Returns collection of appointment and issuccess true. In case of
        /// any error, errormessage is returned with issuccess false</returns>
        public async Task<(bool IsSuccess, IEnumerable<AppointmentViewModel> Appointments, string ErrorMessage)> GetByMonthIdAsync(int monthId)
        {
            try
            {
                // Fetch appointment from the database based on monthid
                // convert dto to viewmodel
                var appointments = _mapper.Map<IEnumerable<AppointmentViewModel>>
                    (await _appointmentRepository.GetAppointmentsByMonth(monthId));
                return (true, appointments, null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} | {ex.StackTrace}");
                return (false, null, ex.Message);
            }
        }

    }
}

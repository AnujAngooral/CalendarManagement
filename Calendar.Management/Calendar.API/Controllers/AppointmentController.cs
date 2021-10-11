using Calendar.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;
        private readonly IAppointmentService _appointmentService;
        /// <summary>
        /// Initialise the Appointment controller with logger and appointment service.
        /// These are injected through the DI
        /// </summary>
        /// <param name="logger">logger to log messages</param>
        /// <param name="appointmentService">appointment service to fetch data related to appointments</param>
        public AppointmentController(ILogger<AppointmentController> logger, IAppointmentService appointmentService)
        {
            _logger = logger;
            _appointmentService = appointmentService;
        }

        /// <summary>
        /// This method is use to return the collection of appointment based on the methodid.
        /// </summary>
        /// <param name="monthId">The id of the month for which you want to fetch the appointments.</param>
        /// <returns>Returns the collection of appointment. In case of any error, 500 internal server error is return </returns>
        [HttpGet]
        [Route("month/{monthId}/appointments")]
        public async Task<IActionResult> GetByMonthId(int monthId)
        {
            _logger.LogInformation("About to call appointment service to get appointments based on monthid");
            var result = await _appointmentService.GetByMonthIdAsync(monthId);

            if (result.IsSuccess)
                return Ok(result.Appointments);

            return StatusCode(500, "Internal Server Error");

        }
        
    }
}

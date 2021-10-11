using AutoMapper;
using Calendar.Dal.Interface;
using Calendar.Services.Interface;
using Calendar.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Services.Impl
{
    public class MonthService : IMonthService
    {
        readonly IMonthRepository _monthRepository;

        private readonly IMapper _mapper;
        private readonly ILogger<MonthService> _logger;

        /// <summary>
        /// Initialise the appointment service with month repo, mapper and logger
        /// These paramters are initialise through the DI
        /// </summary>
        /// <param name="monthRepository">this repo is used to intract with database and insert, fetch
        /// menth related things</param>
        /// <param name="mapper">mapper is used to convert dto to viewmodel and vice vesa</param>
        /// <param name="logger">logger is used to log messages</param>
        public MonthService(IMonthRepository monthRepository, IMapper mapper, ILogger<MonthService> logger)
        {
            _monthRepository = monthRepository;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// This method returns the collection of months.
        /// </summary>
        /// <returns>Returns collection of months and success true. 
        /// In case of any error, errormessage is returned with issuccess false</returns>
        public async Task<(bool IsSuccess, IEnumerable<MonthViewModel> Months, string ErrorMessage)> GetAsync()
        {
            try
            {
                // Fetch collection of months from month repository.
                // Map the dto to the viewmodel object.
                var monthCollection = _mapper.Map<IEnumerable<MonthViewModel>>(await _monthRepository.GetAsync());
                _logger.LogDebug($"Number of months {monthCollection.Count()}");
                return (true, monthCollection, null);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message} | {ex.StackTrace}");
                return (false, null, ex.Message);
            }
        }
    }
}

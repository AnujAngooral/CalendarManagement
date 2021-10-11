using Calendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Services.Interface
{
    public interface IMonthService
    {
        Task<(bool IsSuccess, IEnumerable<MonthViewModel> Months, string ErrorMessage)> GetAsync();
    }
}

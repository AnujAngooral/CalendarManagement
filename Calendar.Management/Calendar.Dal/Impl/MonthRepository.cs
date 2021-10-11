using Calendar.Dal.Dto;
using Calendar.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Dal.Impl
{
    public class MonthRepository : Repository<Month>, IMonthRepository
    {
        public MonthRepository(CalendarDbContext context) : base(context) { }
        public void Dispose()
        {

        }


    }
}

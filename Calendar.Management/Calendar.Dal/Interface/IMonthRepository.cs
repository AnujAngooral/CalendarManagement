
using Calendar.Dal.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.Dal.Interface
{
   public interface IMonthRepository:IRepository<Month>, IDisposable
    {
        //Task Initialise();
    }
}

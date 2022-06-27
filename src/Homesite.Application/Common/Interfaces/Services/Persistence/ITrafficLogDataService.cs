using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Application.Common.Interfaces.Services.Persistence
{
    public interface ITrafficLogDataService
    {
        ITrafficLogDataResult GetCurrentTrafficLogs();
        ITrafficLogDataResult GetTrafficLogsByIP(string ip);
        ITrafficLogDataResult GetTrafficLogsByDate(DateTime startDate, DateTime endDate);
    }
}

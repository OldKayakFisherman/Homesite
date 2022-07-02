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
        Task<ITrafficLogDataResult> GetCurrentTrafficLogs();
        Task<ITrafficLogDataResult> GetTrafficLogsByIP(string ip);
        Task<ITrafficLogDataResult> GetTrafficLogsByDate(DateTime startDate, DateTime endDate);
    }
}

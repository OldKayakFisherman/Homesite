using Homesite.Application.Common.Interfaces.Services.Persistence;
using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Infrastructure.Services.Persistence
{
    public class TrafficLogDataService : ITrafficLogDataService
    {
        public ITrafficLogDataResult GetCurrentTrafficLogs()
        {
            throw new NotImplementedException();
        }

        public ITrafficLogDataResult GetTrafficLogsByDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public ITrafficLogDataResult GetTrafficLogsByIP(string ip)
        {
            throw new NotImplementedException();
        }
    }
}

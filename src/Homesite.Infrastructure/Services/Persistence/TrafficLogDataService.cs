using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Application.Common.Interfaces.Services.Persistence;
using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;
using Homesite.Infrastructure.Services.Responses.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Infrastructure.Services.Persistence
{
    public class TrafficLogDataService : ITrafficLogDataService
    {
        private readonly IApplicationDbContext _context;

        public TrafficLogDataService(IApplicationDbContext ctx)
        {
            _context = ctx;
        }

        public async Task<ITrafficLogDataResult> GetCurrentTrafficLogs()
        {
            ITrafficLogDataResult dataResult = new TrafficLogDataResult();

            //dataResult = 

            return dataResult;
        }

        public Task<ITrafficLogDataResult> GetTrafficLogsByDate(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<ITrafficLogDataResult> GetTrafficLogsByIP(string ip)
        {
            throw new NotImplementedException();
        }
    }
}

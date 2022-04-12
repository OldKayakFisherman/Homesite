using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Application.Common.Interfaces.Services.Logging;
using Homesite.Application.Common.Interfaces.Services.Parameters.Logging;
using Homesite.Domain.Entities;

namespace Homesite.Infrastructure.Services.Logging
{
    public class TrafficLoggerService: ITrafficLoggerService
    {
        private readonly IApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public TrafficLoggerService(IApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task LogTraffic(ITrafficLogParameter parameter, CancellationToken token)
        {
            TrafficLog log = _mapper.Map<TrafficLog>(parameter);

            await _ctx.TrafficLogs.AddAsync(log, token);

            await _ctx.SaveChangesAsync(token);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Parameters.Logging;

namespace Homesite.Application.Common.Interfaces.Services.Logging
{
    public interface ITrafficLoggerService
    {
        Task LogTraffic(ITrafficLogParameter parameter, CancellationToken token);
    }
}

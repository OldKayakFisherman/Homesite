using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Application.Common.Interfaces.Services.Logging;
using Homesite.Application.Common.Interfaces.Services.Parameters.Logging;

namespace Homesite.Infrastructure.Services.Logging
{
    public class ErrorLoggingService: IErrorLoggingService
    {
        private readonly IApplicationDbContext _ctx;

        public ErrorLoggingService(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public void LogRuntimeError(IRuntimeErrorParameter prm)
        {
            
        }
    }
}

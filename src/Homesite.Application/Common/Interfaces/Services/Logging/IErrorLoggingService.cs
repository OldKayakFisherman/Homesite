using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Parameters.Logging;
using Homesite.Domain.Entities;

namespace Homesite.Application.Common.Interfaces.Services.Logging
{
    public interface IErrorLoggingService
    {
        void LogRuntimeError(IRuntimeErrorParameter prm);
    }
}

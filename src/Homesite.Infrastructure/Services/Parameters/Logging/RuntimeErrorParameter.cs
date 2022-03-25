using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Parameters.Logging;

namespace Homesite.Infrastructure.Services.Parameters.Logging
{ 
    public class RuntimeErrorParameter: IRuntimeErrorParameter
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string? Source { get; set; }
        public DateTime ErrorDate { get; set; }
    }
}

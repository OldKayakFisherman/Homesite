using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Application.Common.Interfaces.Services.Parameters.Logging
{
    public  interface IRuntimeErrorParameter
    {
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string? Source { get; set; }
        public DateTime ErrorDate { get; set; }

    }
}

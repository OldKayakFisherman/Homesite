using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Infrastructure.Services.Responses.Persistence
{
    public class TrafficLogDataResult : ITrafficLogDataResult
    {
        public IList<ITrafficDataRecord> Records { get; set; } = new List<ITrafficDataRecord>();

        public ITrafficDataRecord? SingleResult { get; set; }
    }
}

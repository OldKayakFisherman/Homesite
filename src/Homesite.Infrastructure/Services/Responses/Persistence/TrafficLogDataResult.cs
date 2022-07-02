using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Infrastructure.Services.Responses.Persistence
{

    public interface TrafficLogDataRecord
    {
        public int Id { get; set; }

        public int? LocalPort { get; set; }

        public int? RemotePort { get; set; }

        public string? LocalIP { get; set; }

        public string? RemoteIP { get; set; }

        public string? RequestCookies { get; set; }

        public string? RequestHeaders { get; set; }

        public string? Host { get; set; }

        public string? RequestMethod { get; set; }

        public string? RequestPath { get; set; }

        public string? RequestProtocol { get; set; }

        public string? RequestQuery { get; set; }

        public string? RequestScheme { get; set; }

        public long? RequestLength { get; set; }

        public string? RequestContentType { get; set; }

        public string? RequestQueryString { get; set; }

        public DateTime TrafficDate { get; set; }
    }


    public class TrafficLogDataResult : ITrafficLogDataResult
    {
        public IList<ITrafficLogDataRecord> Records { get; set; } = new List<ITrafficLogDataRecord>();

        public ITrafficLogDataRecord? SingleResult { get; set; }
    }
}

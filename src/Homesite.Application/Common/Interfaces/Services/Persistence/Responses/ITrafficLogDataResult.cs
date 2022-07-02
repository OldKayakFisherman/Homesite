using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Application.Common.Interfaces.Services.Persistence.Responses
{

    public interface ITrafficLogDataRecord
    {
        int Id { get; set; }

        int? LocalPort { get; set; }

        int? RemotePort { get; set; }

        string? LocalIP { get; set; }

        string? RemoteIP { get; set; }

        string? RequestCookies { get; set; }

        string? RequestHeaders { get; set; }

        string? Host { get; set; }

        string? RequestMethod { get; set; }

        string? RequestPath { get; set; }

        string? RequestProtocol { get; set; }

        string? RequestQuery { get; set; }

        string? RequestScheme { get; set; }

        long? RequestLength { get; set; }

        string? RequestContentType { get; set; }

        string? RequestQueryString { get; set; }

        DateTime TrafficDate { get; set; }
    }

    public interface ITrafficLogDataResult
    {
        public IList<ITrafficLogDataRecord> Records { get; set; }
        public ITrafficLogDataRecord? SingleResult { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Application.Common.Interfaces.Services.Parameters.Logging
{
    public interface ITrafficLogParameter
    { 
        int? LocalPort { get; set; }

        int? RemotePort { get; set; }

        string? LocalIP { get; set; }

        string? RemoteIP { get; set; }

        string? RequestCookies { get; set; }

        string? RequestFormValues { get; set; }

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

        string? RequestRouteValues { get; set; }

        DateTime TrafficDate { get; set; }
    }
}

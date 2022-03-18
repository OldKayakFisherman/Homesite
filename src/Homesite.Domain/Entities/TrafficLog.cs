using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Domain.Entities
{
    public class TrafficLog
    {
        [Key]
        public int Id { get; set; }

        public int? LocalPort { get; set; }

        public int? RemotePort { get; set; }

        public string? LocalIP { get; set; }

        public string? RemoteIP { get; set; }

        public string? RequestCookies { get; set; }

        public string? RequestFormValues { get; set; }

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

        public string? RequestRouteValues { get; set; }

        public DateTime TrafficDate { get; set; } = DateTime.Now;
    }
}

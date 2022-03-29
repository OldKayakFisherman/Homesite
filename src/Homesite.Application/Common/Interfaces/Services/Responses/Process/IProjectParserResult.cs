using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Application.Common.Interfaces.Services.Responses.Process
{
    public interface IProjectParseRecord
    {
        string? Name { get; set; }
        string? Client { get; set; }
        short StartYear { get; set; }
        short? EndYear { get; set; }
        string? Description { get; set; }

        IList<string>? Roles { get; set; }
        IList<string>? Languages { get; set; }
        IList<string>? Databases { get; set; }
        IList<string>? Toolkits { get; set; }
        IList<string>? Methodologies { get; set; }

    }

    public interface IProjectParserResult
    {
        public TimeSpan Duration { get; set; }
        public bool Success { get; set; }
        public Exception? Error { get; set; }
        public IList<IProjectParseRecord>? ParsedProjects { get; set; }
        public IList<string> Messages { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;

namespace Homesite.Infrastructure.Services.Responses.Process
{
    public class ProjectImportRecord: IProjectImportRecord
    {
        public string? Name { get; set; }
        public string? Client { get; set; }
        public short StartYear { get; set; }
        public short? EndYear { get; set; }
        public string? Description { get; set; }
        public IList<string>? Roles { get; set; } = new List<string>();
        public IList<string>? Languages { get; set; } = new List<string>();
        public IList<string>? Databases { get; set; } = new List<string>();
        public IList<string>? Toolkits { get; set; } = new List<string>();
        public IList<string>? Methodologies { get; set; } = new List<string>();
    }

    public class ProjectImportResult: IProjectImportResult
    {
        public TimeSpan Duration { get; set; }
        public bool Success { get; set; }
        public Exception? Error { get; set; }
        public IList<IProjectImportRecord>? ProjectImports { get; set; } = new List<IProjectImportRecord>();
        public IList<string> Messages { get; set; } = new List<string>();
    }
}

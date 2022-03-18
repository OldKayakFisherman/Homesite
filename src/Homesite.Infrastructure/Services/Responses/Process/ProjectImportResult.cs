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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public IList<string>? Roles { get; set; }
        public IList<string>? Languages { get; set; }
        public IList<string>? Databases { get; set; }
        public IList<string>? Toolkits { get; set; }
        public IList<string>? Methodologies { get; set; }
    }

    public class ProjectImportResult: IProjectImportResult
    {
        public TimeSpan Duration { get; set; }
        public bool Success { get; set; }
        public IList<IProjectImportRecord>? ProjectImports { get; set; }
    }
}

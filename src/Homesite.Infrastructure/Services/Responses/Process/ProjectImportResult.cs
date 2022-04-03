using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;

namespace Homesite.Infrastructure.Services.Responses.Process
{
  
    public class ProjectImportResult: IProjectImportResult
    {
        public bool Success { get; set; }
        public Exception? Error { get; set; }
        public int ProjectImportCount { get; set; } = 0;

    }
}

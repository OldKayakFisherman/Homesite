using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Parameters.Process;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Homesite.Infrastructure.Services.Responses.Process;

namespace Homesite.Infrastructure.Services.Parameters.Process
{
    public class ProjectImportParameters: IProjectImportParameters
    {
        public IList<IProjectParseRecord> ParsedRecords { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;

namespace Homesite.Application.Common.Interfaces.Services.Process
{
    public interface IProjectImportService
    {
        IProjectImportResult ImportProjects(MemoryStream fileData);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Process;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Homesite.Infrastructure.Services.Responses.Process;
using OfficeOpenXml;

namespace Homesite.Infrastructure.Services.Process
{
    public class ProjectImportService: IProjectImportService
    {
        public IProjectImportResult ImportProjects(MemoryStream fileData)
        {
            IProjectImportResult result = new ProjectImportResult();

            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage(fileData))
                {

                }
            }
            catch (Exception ex)
            {

            }

        return result;
        }
    }
}

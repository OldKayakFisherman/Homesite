using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Services.Process;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Homesite.Infrastructure.Services.Process;
using NUnit.Framework;
using TestUtilities;


namespace Homesite.Infrastructure.Tests.Services.Process
{ 
    public class ProjectImportServiceTests
    {
        [Test]
        public void TestImportValidProjects()
        {
            MemoryStream ms = FileTestUtilities.ReadAssetFileAsStream("ProjectImportTestAsset.xlsx", TestContext.CurrentContext);

            Assert.IsNotNull(ms);

            IProjectImportService projectImportService = new ProjectImportService();

            IProjectImportResult result = projectImportService.ImportProjects(ms);

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.ProjectImports.Count == 3);


            
        }
    }
}

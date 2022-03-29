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
    public class ProjectParserServiceTests
    {
        [Test]
        public void TestImportValidProjects()
        {
            MemoryStream ms = FileTestUtilities.ReadAssetFileAsStream("ProjectImportTestAsset.xlsx", TestContext.CurrentContext);

            Assert.IsNotNull(ms);

            IProjectParserService projectParserService = new ProjectParserService();

            IProjectParserResult result = projectParserService.ParseProjects(ms);

            Assert.IsTrue(result.Success);
            Assert.IsTrue(result.ParsedProjects.Count == 3);



        }
    }
}

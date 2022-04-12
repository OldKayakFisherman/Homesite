using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Application.Common.Interfaces.Services.Parameters.Process;
using Homesite.Application.Common.Interfaces.Services.Process;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Homesite.Infrastructure.Services.Parameters.Process;
using Homesite.Infrastructure.Services.Process;
using Homesite.Infrastructure.Services.Responses.Process;
using NUnit.Framework;
using TestUtilities;


namespace Homesite.Infrastructure.Tests.Services.Process
{ 
    public class ProjectImportServiceTests
    {
        [Test]
        public async Task TestProjectImport()
        {

            IApplicationDbContext ctx = DBTestUtilities.CreateDbContext();

            IProjectImportService importService = new ProjectImportService(ctx);

            IProjectParserResult parserResult = new ProjectParserResult();

            IProjectImportParameters prms = new ProjectImportParameters();
            prms.ParsedRecords = DataTestUtilities.CreateTestProjectParseRecords(600);
            
            IProjectImportResult importResult = await importService.ImportProjects(prms, CancellationToken.None);

            Assert.IsNotNull(importResult);
            Assert.IsTrue(importResult.ProjectImportCount > 0);
            Assert.IsTrue(importResult.Success);
            Assert.IsTrue(ctx.Projects.Any());

        }
    }
}

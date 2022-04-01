using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Application.Common.Interfaces.Services.Parameters.Process;
using Homesite.Application.Common.Interfaces.Services.Process;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Homesite.Domain.Entities;
using Homesite.Infrastructure.Mapping;
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
        public void TestProjectImport()
        {


            //IMapper mapper = ConfigurationTestUtilities.BuildMapper(typeof(MappingProfile));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();



            Assert.IsNotNull(mapper);

            IApplicationDbContext ctx = DBTestUtilities.CreateDbContext();

            IProjectImportService importService = new ProjectImportService(ctx, mapper);

            IProjectParserResult parserResult = new ProjectParserResult();

            IProjectImportParameters prms = new ProjectImportParameters();
            prms.ParsedRecords = new DataTestUtilities().CreateTestProjectParseRecords(600);
            

            importService.ImportProjects(prms);


        }
    }
}

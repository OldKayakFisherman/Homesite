using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Application.Common.Interfaces.Services.Parameters.Process;
using Homesite.Application.Common.Interfaces.Services.Process;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Homesite.Domain.Entities;
using Homesite.Infrastructure.Services.Responses.Process;
using OfficeOpenXml;

namespace Homesite.Infrastructure.Services.Process
{
    public class ProjectImportService: IProjectImportService
    {
        private readonly IApplicationDbContext _ctx;
        private readonly IMapper _mapper;

        public ProjectImportService(IApplicationDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
        }

        public IProjectImportResult ImportProjects(IProjectImportParameters projectParserResult)
        {
            ProjectImportResult projectImportResult = new ProjectImportResult();

            
            foreach (IProjectParseRecord record in projectParserResult.ParsedRecords)
            {
                Project entity = _mapper.Map<Project>(record);

            }


            return projectImportResult;
        }
    }
}

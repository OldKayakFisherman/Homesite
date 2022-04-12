﻿using System;
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


        public ProjectImportService(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IProjectImportResult> ImportProjects(IProjectImportParameters projectParserResult, CancellationToken token)
        {
            ProjectImportResult projectImportResult = new ProjectImportResult();

            try
            {

                foreach (ProjectParseRecord record in projectParserResult.ParsedRecords)
                {
                    Project project = new Project()
                    {
                        StartYear = record.StartYear,
                        Name = record.Name,
                        Client = new Client() {Name = record.Client},
                        EndYear = record.EndYear,
                    };

                    foreach (var recordRole in record.Roles)
                    {
                        project.Roles.Add(new ProjectRole() {Name = recordRole});
                    }

                    foreach (var recordLanguage in record.Languages)
                    {
                        project.Languages.Add(new Language() {Name = recordLanguage});
                    }

                    foreach (var recordDatabase in record.Databases)
                    {
                        project.Databases.Add(new Database() {Name = recordDatabase});
                    }

                    foreach (var recordToolkit in record.Toolkits)
                    {
                        project.Toolkits.Add(new Toolkit() {Name = recordToolkit});
                    }

                    foreach (var recordMethodology in record.Methodologies)
                    {
                        project.Methodologies.Add(new Methodology() {Name = recordMethodology});
                    }


                    await _ctx.Projects.AddAsync(project, token);
                    await _ctx.SaveChangesAsync(token);
                    
                    projectImportResult.ProjectImportCount++;

                }

                projectImportResult.Success = true;

            }
            catch (Exception ex)
            {
                projectImportResult.Error = ex;
            }

            return projectImportResult;
        }
    }
}

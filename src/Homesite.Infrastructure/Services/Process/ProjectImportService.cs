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

                        ProjectRole? evalRecord =
                            _ctx.ProjectRoles.FirstOrDefault(x =>
                                x.Name.ToUpper() == recordRole.ToUpper());

                        if (evalRecord != null)
                        {
                            project.Roles.Add(evalRecord);
                        }
                        else
                        {
                            project.Roles.Add(new ProjectRole() { Name = recordRole });
                        }
                       
                    }

                    foreach (var recordLanguage in record.Languages)
                    {

                        Language? evalRecord =
                            _ctx.Languages.FirstOrDefault(x => x.Name.ToUpper() == recordLanguage.ToUpper());

                        if (evalRecord != null)
                        {
                            project.Languages.Add(evalRecord);
                        }
                        else
                        {
                            project.Languages.Add(new Language() { Name = recordLanguage });
                        }


                        
                    }

                    foreach (var recordDatabase in record.Databases)
                    {

                        Database? evalRecord =
                            _ctx.Databases.FirstOrDefault(x =>
                                x.Name.ToUpper() ==recordDatabase.ToUpper());

                        if (evalRecord != null)
                        {
                            project.Databases.Add(evalRecord);
                        }
                        else
                        {
                            project.Databases.Add(new Database() { Name = recordDatabase });
                        }

                    }

                    foreach (var recordToolkit in record.Toolkits)
                    {

                        Toolkit? evalRecord =
                            _ctx.Toolkits.FirstOrDefault(x =>
                               x.Name.ToUpper()== recordToolkit);

                        if (evalRecord != null)
                        {
                            project.Toolkits.Add(evalRecord);
                        }
                        else
                        {
                            project.Toolkits.Add(new Toolkit() { Name = recordToolkit });
                        }

                    }

                    foreach (var recordMethodology in record.Methodologies)
                    {
                        Methodology? evalRecord =
                            _ctx.Methodologies.FirstOrDefault(x =>
                               x.Name.ToUpper() == recordMethodology.ToUpper());

                        if (evalRecord != null)
                        {
                            project.Methodologies.Add(evalRecord);
                        }
                        else
                        {
                            project.Methodologies.Add(new Methodology() { Name = recordMethodology });
                        }

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

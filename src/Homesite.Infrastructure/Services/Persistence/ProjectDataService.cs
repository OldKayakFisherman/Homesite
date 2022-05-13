using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Application.Common.Interfaces.Services.Persistence;
using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;
using Homesite.Domain.Entities;
using Homesite.Infrastructure.Services.Responses.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Homesite.Infrastructure.Services.Persistence
{
    public class ProjectDataService: IProjectDataService
    {

        private readonly IApplicationDbContext _ctx;

        public ProjectDataService(IApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IProjectDataResult> All(CancellationToken token)
        {
            IProjectDataResult result = new ProjectDataResult();

            result.Records = await _ctx.Projects.Select(x => ParseDataRecord(x)).ToListAsync(token);

            return result;
        }

        private static IProjectDataRecord ParseDataRecord(Project project)
        {
            IProjectDataRecord record = new ProjectDataRecord()
            {
                Id = project.Id,
                Name = project.Name,
                StartYear = project.StartYear,
                Description = project.Description,
                EndYear = project.EndYear
            };

            if (project.Client != null)
            {
                record.Client = project.Client.Name;
            }

            if (project.Databases != null)
            {
                foreach (var subRecord in project.Databases)
                {
                    record.Databases.Add(subRecord.Name);   
                }
            }

            if (project.Languages != null)
            {
                foreach (var subRecord in project.Languages)
                {
                    record.Languages.Add(subRecord.Name);
                }
            }

            if (project.Methodologies != null)
            {
                foreach (var subRecord in project.Methodologies)
                {
                    record.Methodologies.Add(subRecord.Name);
                }
            }

            if (project.Roles != null)
            {
                foreach (var subRecord in project.Roles)
                {
                    record.Roles.Add(subRecord.Name);
                }
            }


            if (project.Toolkits != null)
            {
                foreach (var subRecord in project.Toolkits)
                {
                    record.Toolkits.Add(subRecord.Name);
                }
            }



            return record;

        }
    }
}

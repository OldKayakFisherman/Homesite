using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Homesite.Application.Common.Interfaces.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<TrafficLog> TrafficLogs { get;  }
        DbSet<Notification> Notifications { get; }
        DbSet<BannedIP> BannedIPs { get; }
        DbSet<Client> Clients { get; }
        DbSet<Database> Databases { get; }
        DbSet<Language> Languages { get; }
        DbSet<Methodology> Methodologies { get; }
        DbSet<Project> Project { get; }
        DbSet<ProjectRole> ProjectRoles { get; }
        DbSet<Toolkit> Toolkits { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

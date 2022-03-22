using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Domain.Entities;
using Homesite.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Homesite.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<TrafficLog> TrafficLogs => Set<TrafficLog>();
        public DbSet<Notification> Notifications => Set<Notification>();
        public DbSet<BannedIP> BannedIPs => Set<BannedIP>();

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Database> Databases => Set<Database>();
        public DbSet<Language> Languages => Set<Language>();
        public DbSet<Methodology> Methodologies => Set<Methodology>();
        public DbSet<Project> Project => Set<Project>();
        public DbSet<ProjectRole> ProjectRoles => Set<ProjectRole>();
        public DbSet<Toolkit> Toolkits => Set<Toolkit>();
    }
}

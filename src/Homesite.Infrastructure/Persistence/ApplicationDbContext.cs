using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Domain.Entities;
using Homesite.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Homesite.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration conf)
            : base(options)
        {
            _configuration = conf;
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
        public DbSet<RuntimeError> RuntimeErrors => Set<RuntimeError>();


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedUsers(builder);
            SeedRoles(builder);
            SeedUserRoles(builder);
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "6f276b20-5381-4320-a562-64b4bcca0f0f", UserId = "760bef19-4266-43e0-a6b0-37c46ea31316" }
                );

        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "6f276b20-5381-4320-a562-64b4bcca0f0f", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" }
            );
        }

        private void SeedUsers(ModelBuilder builder)
        {

           

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            ApplicationUser adminUser = new ApplicationUser()
            {
                Id = "760bef19-4266-43e0-a6b0-37c46ea31316",
                UserName = _configuration["site.admin.email"],
                Email = _configuration["site.admin.email"],
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                NormalizedUserName = _configuration["site.admin.email"]

            };


            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, _configuration["site.admin.password"]);

            builder.Entity<ApplicationUser>().HasData(adminUser);


        }


    }
}

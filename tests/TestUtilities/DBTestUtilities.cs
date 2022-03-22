using Homesite.Application.Common.Interfaces;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Domain.Entities;
using Homesite.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace TestUtilities
{
    public static class DBTestUtilities
    {
        public static DbContextOptions CreateOptions<T>()
            where T : DbContext
        {
            //This creates the SQLite connection string to in-memory database
            var connectionStringBuilder = new SqliteConnectionStringBuilder
            { DataSource = ":memory:" };
            var connectionString = connectionStringBuilder.ToString();

            //This creates a SqliteConnectionwith that string
            var connection = new SqliteConnection(connectionString);

            //The connection MUST be opened here
            connection.Open();

            //Now we have the EF Core commands to create SQLite options
            var builder = new DbContextOptionsBuilder<T>();
            builder.UseSqlite(connection);


            return builder.Options;
        }

        public static IApplicationDbContext CreateDbContext()
        {
            var options = CreateOptions<ApplicationDbContext>();

            var ctx = new ApplicationDbContext((DbContextOptions<ApplicationDbContext>)options);

            ctx.Database.EnsureCreated();

            return ctx;

        }

        




    }
}
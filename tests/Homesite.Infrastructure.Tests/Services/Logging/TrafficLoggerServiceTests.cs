using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Homesite.Application.Common.Interfaces.Persistence;
using Homesite.Application.Common.Interfaces.Services.Logging;
using Homesite.Infrastructure.Mapping;
using Homesite.Infrastructure.Services.Logging;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using TestUtilities;

namespace Homesite.Infrastructure.Tests.Services.Logging
{
    [TestFixture]
    public class TrafficLoggerServiceTests
    {
        [Test]
        public async Task TestLogTraffic()
        {
            IMapper mapper = ConfigurationTestUtilities.BuildMapper(typeof(MappingProfile));
            IApplicationDbContext ctx = DBTestUtilities.CreateDbContext();

            ITrafficLoggerService service = new TrafficLoggerService
            (
                ctx,
                mapper
            );

            await service.LogTraffic(DataTestUtilities.CreateTestTrafficLogParameter(), CancellationToken.None);

            Assert.IsTrue(await ctx.TrafficLogs.CountAsync() > 0);
        }
    }
}

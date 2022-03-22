using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtilities
{
    public static class ConfigurationTestUtilities
    {
        public static IConfiguration BuildTestConfiguration()
        {
            var inMemorySettings = new Dictionary<string, string> {
                {"WorkDir", "work"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            return configuration;
        }

        public static IHostEnvironment BuildTestHostEnvironment(TestContext ctx)
        {
            var hostMock = new Mock<IHostEnvironment>();

            hostMock.Setup(x => x.ContentRootPath).Returns(ctx.TestDirectory);

            return hostMock.Object;

        }
    }
}

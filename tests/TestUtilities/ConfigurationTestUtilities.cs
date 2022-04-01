using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Homesite.Infrastructure.Mapping;

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

            configuration["site.admin.email"] = "some.email@test.com";
            configuration["site.admin.password"] = "supersecretpassword1239@!";

            return configuration;
        }

        public static IHostEnvironment BuildTestHostEnvironment(TestContext ctx)
        {
            var hostMock = new Mock<IHostEnvironment>();

            hostMock.Setup(x => x.ContentRootPath).Returns(ctx.TestDirectory);

            return hostMock.Object;

        }

        public static IMapper BuildMapper(Type profileClass)
        {
            
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(profileClass);
            });

            return new Mapper(config);
            

            
        }
    }
}

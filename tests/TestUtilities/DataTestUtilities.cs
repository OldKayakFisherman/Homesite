using Homesite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Homesite.Application.Common.Interfaces.Services.Parameters.Logging;
using Homesite.Infrastructure.Services.Parameters.Logging;
using Homesite.Infrastructure.Services.Responses.Process;

namespace TestUtilities
{
    public class DataTestUtilities
    {

        public static ITrafficLogParameter CreateTestTrafficLogParameter()
        {
            ITrafficLogParameter parameter = new TrafficLogParameter();

            Faker fk = new Faker();

            parameter.Host = fk.Internet.DomainName();
            parameter.LocalIP = fk.Internet.Ip();
            parameter.LocalPort = fk.Internet.Port();
            parameter.RemoteIP = fk.Internet.Ip();
            parameter.RemotePort = fk.Internet.Port();
            parameter.RequestContentType = fk.Random.AlphaNumeric(15);
            parameter.RequestCookies = fk.Random.AlphaNumeric(150);
            parameter.RequestHeaders = fk.Random.AlphaNumeric(150);
            parameter.RequestLength = 1024;
            parameter.RequestMethod = "GET";
            parameter.RequestPath = fk.Internet.UrlRootedPath();
            parameter.RequestProtocol = fk.Internet.Protocol();
            parameter.RequestQuery = fk.Random.AlphaNumeric(25);
            parameter.RequestQueryString = "?id=1";
            parameter.RequestRouteValues = fk.Random.AlphaNumeric(25);
            parameter.RequestScheme = fk.Internet.Protocol();
            parameter.TrafficDate = DateTime.Now;
            

            return parameter;

        }

        public static IList<IProjectParseRecord> CreateTestProjectParseRecords(int count)
        {
            IList<IProjectParseRecord> retval = new List<IProjectParseRecord>();

            Faker fk = new Faker();

            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {

                    IProjectParseRecord importRecord = new ProjectParseRecord();

                    importRecord.StartYear = short.Parse(fk.Date.PastDateOnly(5).Year.ToString());
                    importRecord.Client = fk.Company.CompanyName();
                    importRecord.Name = fk.Random.AlphaNumeric(15);
                    importRecord.Description = fk.Random.AlphaNumeric(150);

                    importRecord.Databases.Add(fk.Database.Engine());
                    importRecord.Databases.Add(fk.Database.Engine());

                    importRecord.Languages.Add(fk.Random.AlphaNumeric(5));

                    importRecord.Methodologies.Add(fk.Random.AlphaNumeric(15));

                    importRecord.Roles.Add(fk.Random.AlphaNumeric(15));
                    importRecord.Roles.Add(fk.Random.AlphaNumeric(15));
                    importRecord.Roles.Add(fk.Random.AlphaNumeric(15));

                    importRecord.Toolkits.Add(fk.Random.AlphaNumeric(15));
                    importRecord.Toolkits.Add(fk.Random.AlphaNumeric(15));
                    importRecord.Toolkits.Add(fk.Random.AlphaNumeric(15));
                    importRecord.Toolkits.Add(fk.Random.AlphaNumeric(15));
                    importRecord.Toolkits.Add(fk.Random.AlphaNumeric(15));

                    retval.Add(importRecord);
                }
            }

            return retval;
        }
    }
}

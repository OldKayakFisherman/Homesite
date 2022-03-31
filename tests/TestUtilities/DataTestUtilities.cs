using Homesite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using Homesite.Application.Common.Interfaces.Services.Responses.Process;
using Bogus;
using Homesite.Infrastructure.Services.Responses.Process;

namespace TestUtilities
{
    public class DataTestUtilities
    {
        public IList<IProjectParseRecord> CreateTestProjectParseRecords(int count)
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

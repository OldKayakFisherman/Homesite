using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homesite.Application.Common.Interfaces.Persistence.Responses;

namespace Homesite.Infrastructure.Services.Responses.Persistence
{

    public class ProjectDataRecord: IProjectDataRecord
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public short StartYear { get; set; }
        public short? EndYear { get; set; }
        public string Client { get; set; }


        public IList<string>? Roles { get; set; } = new List<string>();
        public IList<string>? Languages { get; set; } = new List<string>();
        public IList<string>? Databases { get; set; } = new List<string>();
        public IList<string>? Toolkits { get; set; } = new List<string>();
        public IList<string>? Methodologies { get; set; } = new List<string>();
    }

    public class ProjectDataResult: IProjectDataResult
    {
        public IList<IProjectDataRecord> Records { get; set; } = new List<IProjectDataRecord>();
        public IProjectDataRecord? SingleResult {
            get
            {

                IProjectDataRecord record = null;

                if (Records != null && Records.Count > 0)
                {
                    record = Records.ElementAt(0);
                }

                return record;
            }
        }
    }
}

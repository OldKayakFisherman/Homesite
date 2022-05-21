using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;

namespace Homesite.Web.Models
{
    public class ProjectDisplayViewModel
    {
        public IList<IProjectDataRecord> Projects { get; set; } = new List<IProjectDataRecord>();

    }
}

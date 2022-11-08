


using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;
using System.ComponentModel;

namespace Homesite.Web.Models
{
    
    public class ProjectUploadViewModel
    {
        [DisplayName("Project Upload File")]
        public IFormFile? ProjectUpload { get; set; }

        public bool HasFileUpload {
            get
            {
                return (ProjectUpload != null);
            }
        }
        public IList<string> Errors { get; set; } = new List<string>();
        public IList<ProjectSimpleViewModel>? ExistingProjects { get; set; } = new List<ProjectSimpleViewModel>();
        public bool HasProjects => ExistingProjects is {Count: > 0};
        public bool HasErrors => Errors is { Count: > 0 };

        public void PopulateExistingProjects(IList<IProjectDataRecord> records)
        {
            if(records != null && records.Count > 0)
            {
                foreach (var projectDataRecord in records)
                {
                    ExistingProjects.Add(new ProjectSimpleViewModel()
                    {
                        Name = projectDataRecord.Name, 
                        Client = projectDataRecord .Client,
                        Id = projectDataRecord.Id
                    });   
                }
            }
        }

    }
}

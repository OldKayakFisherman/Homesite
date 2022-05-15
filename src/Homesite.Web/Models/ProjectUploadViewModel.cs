


using System.ComponentModel;
using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;

namespace Homesite.Web.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        public string DeleteId => $"chkDelete{this.Id}";
    }

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
        public IList<ProjectViewModel>? ExistingProjects { get; set; } = new List<ProjectViewModel>();
        public bool HasProjects => ExistingProjects is {Count: > 0};
        public bool HasErrors => Errors is { Count: > 0 };

        public void PopulateExistingProjects(IList<IProjectDataRecord> records)
        {
            if(records != null && records.Count > 0)
            {
                foreach (var projectDataRecord in records)
                {
                    ExistingProjects.Add(new ProjectViewModel()
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

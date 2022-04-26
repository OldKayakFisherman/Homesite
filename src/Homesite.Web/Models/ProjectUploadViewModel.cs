


using System.ComponentModel;

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

        public IList<ProjectViewModel>? ExistingProjects { get; set; } = new List<ProjectViewModel>();
        public IList<int>? ProjectsToRemove { get; set; }
        public bool HasProjects => ExistingProjects is {Count: > 0};
    }
}

namespace Homesite.Web.Models
{
    public class ProjectSimpleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        public string DeleteId => $"chkDelete{this.Id}";
    }
}

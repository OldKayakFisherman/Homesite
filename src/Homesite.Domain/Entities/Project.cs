using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public short StartYear { get; set; }
        public short? EndYear { get; set; }
        public Client? Client { get; set; }


        public ICollection<ProjectRole>? Roles { get; set; } = new List<ProjectRole>();
        public ICollection<Language>? Languages { get; set; } = new List<Language>();
        public ICollection<Database>? Databases { get; set; } = new List<Database>();
        public ICollection<Toolkit>? Toolkits { get; set; } = new List<Toolkit>();
        public ICollection<Methodology>? Methodologies { get; set; } = new List<Methodology>();

    }
}

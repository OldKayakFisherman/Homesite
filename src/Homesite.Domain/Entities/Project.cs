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
        public string? Summary { get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Client? Client { get; set; }

        public ICollection<ProjectRole>? Roles { get; set; }
        public ICollection<Language>? Languages { get; set; }
        public ICollection<Database>? Databases { get; set; }
        public ICollection<DesignPattern>? DesignPatterns { get; set; }
        public ICollection<Toolkit>? Toolkits { get; set; }
        public ICollection<Methodology>? Methodologies { get; set; }

    }
}

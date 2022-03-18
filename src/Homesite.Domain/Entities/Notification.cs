using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Domain.Entities
{
    public class Notification
    {
        [Key] public int Id { get; set; }

        public string? NotificationType { get; set; }

        public string? Requester { get; set; }

        public DateTime Created { get; set; }

        public string? Description { get; set; }
        public DateTime? Reviewed { get; set; }
    }

}

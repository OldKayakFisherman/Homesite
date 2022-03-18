using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Domain.Entities
{
    public class BannedIP
    {
        [Key]
        public int Id { get; set; }

        public string? IP { get; set; }
    }
}

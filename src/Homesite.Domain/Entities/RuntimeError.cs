using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homesite.Domain.Entities
{
    public class RuntimeError
    {
        public int Id { get; set; }
        public int ErrorCode { get; set; }
        public string Message { get; set; }
        public string? Source { get; set; }
        public DateTime ErrorDate { get; set; }


      
    }
}

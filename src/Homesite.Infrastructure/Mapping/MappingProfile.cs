using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Homesite.Domain.Entities;
using Homesite.Infrastructure.Services.Parameters.Logging;

namespace Homesite.Infrastructure.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<RuntimeErrorParameter, RuntimeError>();
        }
    }
}

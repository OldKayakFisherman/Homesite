using AutoMapper;
using Homesite.Application.Common.Interfaces.Services.Parameters.Logging;
using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;
using Homesite.Domain.Entities;


namespace Homesite.Infrastructure.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<ITrafficLogParameter, TrafficLog>();
            CreateMap<ITrafficLogDataRecord, TrafficLog>();
        }
    }
}

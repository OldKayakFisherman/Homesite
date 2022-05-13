using Homesite.Application.Common.Interfaces.Services.Persistence.Responses;

namespace Homesite.Application.Common.Interfaces.Services.Persistence;

public interface IProjectDataService
{
    Task<IProjectDataResult> All(CancellationToken token);
}
namespace Homesite.Application.Common.Interfaces.Services.Persistence;

public interface IProjectDataService
{
    Task<IProjectDataResult> All(CancellationToken token);
    Task DeleteProjects(IList<int> ids, CancellationToken token);
}
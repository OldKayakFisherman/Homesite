namespace Homesite.Application.Common.Interfaces.Services.Responses.Process
{

    public interface IProjectImportResult
    {
        bool Success { get; set; }
        Exception? Error { get; set; }
        int ProjectImportCount { get; set; }
    }
}

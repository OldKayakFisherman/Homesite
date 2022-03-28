namespace Homesite.Application.Common.Interfaces.Services.Responses.Process
{

    public interface IProjectImportRecord
    {

        string? Name { get; set; }
        string? Client { get; set; }
        short StartYear { get; set; }
        short? EndYear { get; set; }
        string? Description { get; set; }

        IList<string>? Roles { get; set; }
        IList<string>? Languages { get; set; }
        IList<string>? Databases { get; set; }
        IList<string>? Toolkits { get; set; }
        IList<string>? Methodologies { get; set; }


    }

    public interface IProjectImportResult
    {
        TimeSpan Duration { get; set; }
        bool Success { get; set; }
        Exception? Error { get; set; }
        IList<IProjectImportRecord>? ProjectImports { get; set; }
        IList<string> Messages { get; set; }
    }
}

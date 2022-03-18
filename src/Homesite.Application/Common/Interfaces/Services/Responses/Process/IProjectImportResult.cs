namespace Homesite.Application.Common.Interfaces.Services.Responses.Process
{

    public interface IProjectImportRecord
    {

        string Name { get; set; }
        string Client { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Description { get; set; }

        IList<string>? Roles { get; set; }
        IList<string>? Languages { get; set; }
        IList<string>? Databases { get; set; }
        IList<string>? DesignPatterns { get; set; }
        IList<string>? Toolkits { get; set; }
        IList<string>? Methodologies { get; set; }


    }

    public interface IProjectImportResult
    {
        TimeSpan Duration { get; set; }
        bool Success { get; set; }

        IList<IProjectImportRecord> ProjectImports { get; set; }
    }
}

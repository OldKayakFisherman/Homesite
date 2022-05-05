namespace Homesite.Application.Common.Interfaces.Services.Persistence.Responses;

public interface IProjectDataRecord
{
    int Id { get; set; }
    string? Description { get; set; }
    string? Name { get; set; }
    short StartYear { get; set; }
    short? EndYear { get; set; }
    string Client { get; set; }


    IList<string>? Roles { get; set; }
    IList<string>? Languages { get; set; }
    IList<string>? Databases { get; set; }
    IList<string>? Toolkits { get; set; }
    IList<string>? Methodologies { get; set; }
}

public interface IProjectDataResult
{
    public IList<IProjectDataRecord> Records { get; set; }
    public IProjectDataRecord? SingleResult { get; }

}
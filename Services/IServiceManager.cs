using tickets.Services.Team;

namespace tickets.Services;

public interface IServiceManager
{
    ITeamService TeamService { get; }

    Task SaveAsync();
}
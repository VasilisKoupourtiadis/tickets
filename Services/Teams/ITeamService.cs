using tickets.Models;

namespace tickets.Services.Teams;

public interface ITeamService
{
    Task<Team> GetTeamAsync(Guid id);

    Task<ICollection<Team>> GetTeamsAsync();
}
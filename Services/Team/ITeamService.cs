namespace tickets.Services.Team;

public interface ITeamService
{
    Task<Models.Team> GetTeamAsync(Guid id);

    Task<ICollection<Models.Team>> GetTeamsAsync();
}
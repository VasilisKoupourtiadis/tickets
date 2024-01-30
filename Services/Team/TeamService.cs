using Microsoft.EntityFrameworkCore;
using tickets.Data;

namespace tickets.Services.Team;

public class TeamService : ITeamService
{
    private readonly ApplicationContext context;

    public TeamService(ApplicationContext context)
    {
        this.context = context;
    }

    public async Task<ICollection<Models.Team>> GetTeamsAsync() =>
        await context.Teams.ToListAsync();

    public async Task<Models.Team> GetTeamAsync(Guid id) =>
        await context.Teams.FirstOrDefaultAsync(x => x.Id.Equals(id));
}

using Microsoft.EntityFrameworkCore;
using tickets.Data;
using tickets.Models;

namespace tickets.Services.Teams;

public class TeamService : ITeamService
{
    private readonly ApplicationContext context;

    public TeamService(ApplicationContext context)
    {
        this.context = context;
    }

    public async Task<ICollection<Team>> GetTeamsAsync() =>
        await context.Teams
        .Include(x => x.Members)
        .ThenInclude(x => x.Tickets)
        .ToListAsync();

    public async Task<Team> GetTeamAsync(Guid id) =>
        await context.Teams
        .Include(x => x.Members)
        .ThenInclude(x => x.Tickets)
        .FirstOrDefaultAsync(x => x.Id.Equals(id));
}

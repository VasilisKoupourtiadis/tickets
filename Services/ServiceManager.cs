using tickets.Data;
using tickets.Services.Team;

namespace tickets.Services;

public class ServiceManager : IServiceManager
{
    private readonly ApplicationContext context;

    private ITeamService teamService;

    public ServiceManager(ApplicationContext context)
    {
        this.context = context;
    }

    public ITeamService TeamService
    {
        get
        {
            var service = teamService is not null
                ? teamService
                : teamService = new TeamService(context);
            return service;
        }
    }

    public Task SaveAsync() => context.SaveChangesAsync();
}

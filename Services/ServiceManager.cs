using tickets.Data;
using tickets.Services.Employees;
using tickets.Services.Teams;

namespace tickets.Services;

public class ServiceManager : IServiceManager
{
    private readonly ApplicationContext context;

    private ITeamService teamService;

    private IEmployeeService employeeService;

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

    public IEmployeeService EmployeeService
    {
        get
        {
            var service = employeeService is not null
                ? employeeService
                : employeeService = new EmployeeService(context);
            return service;
        }
    }

    public Task SaveAsync() => context.SaveChangesAsync();
}

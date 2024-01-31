using tickets.Services.Employees;
using tickets.Services.Teams;

namespace tickets.Services;

public interface IServiceManager
{
    ITeamService TeamService { get; }

    IEmployeeService EmployeeService { get; }

    Task SaveAsync();
}
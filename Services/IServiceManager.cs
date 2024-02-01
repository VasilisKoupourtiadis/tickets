using tickets.Services.Employees;
using tickets.Services.Teams;
using tickets.Services.Tickets;

namespace tickets.Services;

public interface IServiceManager
{
    ITeamService TeamService { get; }

    IEmployeeService EmployeeService { get; }

    ITicketService TicketService { get; }

    Task SaveAsync();
}
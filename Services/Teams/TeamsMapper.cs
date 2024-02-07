using AutoMapper;
using tickets.Models;
using tickets.Services.Teams.Queries;

namespace tickets.Services.Teams;

public class TeamsMapper : Profile
{
    public TeamsMapper()
    {
        CreateMap<Team, GetAllTeams.TeamsResult>();

        CreateMap<Employee, GetAllTeams.EmployeeResult>();

        CreateMap<Ticket, GetAllTeams.TicketResult>();

        CreateMap<Team, GetTeam.TeamResult>();

        CreateMap<Employee, GetTeam.EmployeeResult>();

        CreateMap<Ticket, GetTeam.TicketResult>();
    }
}

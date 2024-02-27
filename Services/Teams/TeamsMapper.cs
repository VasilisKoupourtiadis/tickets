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

        CreateMap<Ticket, GetAllTeams.TicketResult>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(x => x.Created.ToString("dd MMM yyyy, HH:mm")))
            .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(x => x.Employee.FullName));

        CreateMap<Team, GetTeam.TeamResult>();

        CreateMap<Employee, GetTeam.EmployeeResult>();

        CreateMap<Ticket, GetTeam.TicketResult>();
    }
}

using AutoMapper;
using tickets.Models;
using tickets.Services.Employees.Queries;

namespace tickets.Services.Employees;

public class EmployeesMapper : Profile
{
    public EmployeesMapper()
    {
        CreateMap<Employee, GetAllEmployees.EmployeesResult>()
            .ForMember(dest => dest.TeamName, opt => opt.MapFrom(x => x.Team.Name));

        CreateMap<Ticket, GetAllEmployees.TicketResult>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(x => x.Created.ToString("dd MMM yyyy, HH:mm")));

        CreateMap<Employee, GetEmployee.EmployeeResult>()
            .ForMember(dest => dest.TeamName, opt => opt.MapFrom(x => x.Team.Name));

        CreateMap<Ticket, GetEmployee.TicketResult>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(x => x.Created.ToString("dd MMM yyyy, HH:mm")));
    }
}

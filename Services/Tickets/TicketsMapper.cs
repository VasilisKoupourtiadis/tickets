using AutoMapper;
using tickets.Models;
using tickets.Services.Tickets.Queries;

namespace tickets.Services.Tickets;

public class TicketsMapper : Profile
{
    public TicketsMapper()
    {
        CreateMap<Ticket, GetAllTickets.TicketsResult>()
            .ForMember(dest => dest.Created, opt => opt.MapFrom(x => x.Created.ToString("dd MMM yyyy, HH:mm")));

        CreateMap<Employee, GetAllTickets.EmployeeResult>();
    }
}

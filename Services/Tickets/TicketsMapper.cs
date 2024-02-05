using AutoMapper;
using tickets.Models;
using tickets.Services.Tickets.Queries;

namespace tickets.Services.Tickets;

public class TicketsMapper : Profile
{
    public TicketsMapper()
    {
        CreateMap<Ticket, GetAllTickets.TicketsResult>();

        CreateMap<Employee, GetAllTickets.EmployeeResult>();
    }
}

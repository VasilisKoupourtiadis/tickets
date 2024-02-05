using AutoMapper;
using tickets.Models;
using tickets.Services.Employees.Queries;

namespace tickets.Services.Employees;

public class EmployeesMapper : Profile
{
    public EmployeesMapper()
    {
        CreateMap<Employee, GetAllEmployees.EmployeesResult>();

        CreateMap<Ticket, GetAllEmployees.TicketResult>();
    }
}

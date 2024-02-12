using AutoMapper;
using MediatR;
using static tickets.Services.Teams.Queries.GetAllTeams;

namespace tickets.Services.Employees.Queries;

public class GetAllEmployees
{
    public class GetAllEmployeesQuery : IRequest<ICollection<EmployeesResult>> { }

    public class EmployeesResult
    {
        public Guid Id { get; set; }

        public string FullName { get; private set; } = string.Empty;

        public string Title { get; private set; } = string.Empty;

        public string TeamName { get; private set; } = string.Empty;

        public ICollection<TicketResult> Tickets { get; private set; } = new List<TicketResult>();
    }

    public class TicketResult
    {
        public Guid Id { get; set; }

        public string Title { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public string Status { get; private set; } = string.Empty;

        public string Created { get; set; } = string.Empty;
    }

    public class Handler : IRequestHandler<GetAllEmployeesQuery, ICollection<EmployeesResult>> 
    {
        private readonly IServiceManager serviceManager;

        private readonly IMapper mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            this.serviceManager = serviceManager;
            this.mapper = mapper;
        }

        public async Task<ICollection<EmployeesResult>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await serviceManager.EmployeeService.GetEmployeesAsync();

            var results = mapper.Map<ICollection<EmployeesResult>>(employees);

            return results;
        }
    }
}

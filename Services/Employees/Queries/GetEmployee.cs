using AutoMapper;
using MediatR;

namespace tickets.Services.Employees.Queries;

public class GetEmployee
{
    public class GetEmployeeQuery : IRequest<EmployeeResult>
    {
        public Guid Id { get; set; }
    }

    public class EmployeeResult
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

    public class Handler : IRequestHandler<GetEmployeeQuery, EmployeeResult>
    {
        private readonly IServiceManager serviceManager;

        private readonly IMapper mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            this.serviceManager = serviceManager;
            this.mapper = mapper;
        }

        public async Task<EmployeeResult> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employee = await serviceManager.EmployeeService.GetEmployeeAsync(request.Id);

            var result = mapper.Map<EmployeeResult>(employee);

            return result;
        }
    }
}

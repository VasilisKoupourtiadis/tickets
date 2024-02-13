using AutoMapper;
using MediatR;

namespace tickets.Services.Tickets.Queries;

public class GetTicket
{
    public class GetTicketQuery : IRequest<TicketResult>
    {
        public Guid Id { get; set; }
    }

    public class TicketResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Created { get; set; } = string.Empty;

        public EmployeeResult Employee { get; set; } = new EmployeeResult();
    }

    public class EmployeeResult
    {
        public Guid Id { get; set; }

        public string FullName { get; private set; } = string.Empty;

        public string Title { get; private set; } = string.Empty;
    }

    public class Handler : IRequestHandler<GetTicketQuery, TicketResult>
    {
        private readonly IServiceManager serviceManager;

        private readonly IMapper mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            this.serviceManager = serviceManager;
            this.mapper = mapper;
        }

        public async Task<TicketResult> Handle(GetTicketQuery request, CancellationToken cancellationToken)
        {
            var ticket = await serviceManager.TicketService.GetTicketAsync(request.Id);

            var result = mapper.Map<TicketResult>(ticket);

            return result;
        }
    }
}

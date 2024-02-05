using AutoMapper;
using MediatR;

namespace tickets.Services.Tickets.Queries;

public class GetAllTickets
{
    public class GetAllTicketsQuery : IRequest<ICollection<TicketsResult>> { }

    public class TicketsResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public EmployeeResult Employee { get; set; } = new EmployeeResult();
    }

    public class EmployeeResult
    {
        public Guid Id { get; set; }

        public string FullName { get; private set; } = string.Empty;

        public string Title { get; private set; } = string.Empty;
    }

    public class Handler : IRequestHandler<GetAllTicketsQuery, ICollection<TicketsResult>> 
    {
        private readonly IServiceManager serviceManager;

        private readonly IMapper mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            this.serviceManager = serviceManager;
            this.mapper = mapper;
        }

        public async Task<ICollection<TicketsResult>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
        {
            var tickets = await serviceManager.TicketService.GetTicketsAsync();

            var result = mapper.Map<ICollection<TicketsResult>>(tickets);

            return result;
        }
    }
}

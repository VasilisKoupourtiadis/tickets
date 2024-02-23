using AutoMapper;
using MediatR;
using static tickets.Services.Tickets.Queries.GetTicket;

namespace tickets.Services.Tickets.Commands;

public class UpdateTicketStatus
{
    public class UpdateTicketStatusCommand : IRequest<TicketResult> 
    { 
        public Guid Id { get; set; }

        public string Status { get; set; } = string.Empty;
    }    

    public class Handler : IRequestHandler<UpdateTicketStatusCommand, TicketResult>
    {
        private readonly IServiceManager serviceManager;

        private readonly IMapper mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            this.serviceManager = serviceManager;
            this.mapper = mapper;
        }

        public async Task<TicketResult> Handle(UpdateTicketStatusCommand request, CancellationToken cancellationToken)
        {
            var ticket = await serviceManager.TicketService.GetTicketAsync(request.Id);

            if (request.Status.ToLower() == "active")
            {
                ticket.SetClosedStatus();
            }
            else if (request.Status.ToLower() == "pending")
            {
                ticket.SetActiveStatus();
            }
           
            await serviceManager.SaveAsync();

            var result = mapper.Map<TicketResult>(ticket);

            return result;
        }
    }
}

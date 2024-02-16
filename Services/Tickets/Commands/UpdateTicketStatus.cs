using AutoMapper;
using MediatR;

namespace tickets.Services.Tickets.Commands;

public class UpdateTicketStatus
{
    public class UpdateTicketStatusCommand : IRequest<Unit> 
    { 
        public Guid Id { get; set; }

        public string Status { get; set; } = string.Empty;
    }

    public class Handler : IRequestHandler<UpdateTicketStatusCommand, Unit>
    {
        private readonly IServiceManager serviceManager;

        public Handler(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public async Task<Unit> Handle(UpdateTicketStatusCommand request, CancellationToken cancellationToken)
        {
            var ticket = await serviceManager.TicketService.GetTicketAsync(request.Id);

            if(request.Status.ToLower() == "active")
            {
                ticket.SetClosedStatus();
            }

            ticket.SetActiveStatus();

            await serviceManager.SaveAsync();

            return Unit.Value;
        }
    }
}

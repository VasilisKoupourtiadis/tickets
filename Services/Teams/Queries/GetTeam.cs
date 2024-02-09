using AutoMapper;
using MediatR;

namespace tickets.Services.Teams.Queries;

public class GetTeam
{
    public class GetTeamQuery : IRequest<TeamResult>
    {
        public Guid Id { get; set; }
    }

    public class TeamResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<EmployeeResult> Members { get; set; } = new List<EmployeeResult>();
    }

    public class EmployeeResult
    {
        public Guid Id { get; set; }

        public string FullName { get; private set; } = string.Empty;

        public string Title { get; private set; } = string.Empty;

        public ICollection<TicketResult> Tickets { get; private set; } = new List<TicketResult>();
    }

    public class TicketResult
    {
        public Guid Id { get; set; }

        public string Title { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public string Status { get; private set; } = string.Empty;
    }

    public class Handler : IRequestHandler<GetTeamQuery, TeamResult>
    {
        private readonly IServiceManager serviceManager;

        private readonly IMapper mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            this.serviceManager = serviceManager;
            this.mapper = mapper;
        }

        public async Task<TeamResult> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var team = await serviceManager.TeamService.GetTeamAsync(request.Id);

            var result = mapper.Map<TeamResult>(team);

            return result;
        }
    }
}

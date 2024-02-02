using AutoMapper;
using MediatR;
using tickets.Models;

namespace tickets.Services.Teams.Queries;

public class GetAllTeams
{
    public class GetAllTeamsQuery : IRequest<ICollection<TeamsResult>> { }

    public class TeamsResult
    {
        public Guid Id { get; set; }

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

    public class Handler : IRequestHandler<GetAllTeamsQuery, ICollection<TeamsResult>>
    {
        private readonly IServiceManager serviceManager;

        private readonly IMapper mapper;

        public Handler(IServiceManager serviceManager, IMapper mapper)
        {
            this.serviceManager = serviceManager;
            this.mapper = mapper;
        }

        public async Task<ICollection<TeamsResult>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            var teams = await serviceManager.TeamService.GetTeamsAsync();

            var results = mapper.Map<ICollection<TeamsResult>>(teams);

            return results;
        }
    }
}

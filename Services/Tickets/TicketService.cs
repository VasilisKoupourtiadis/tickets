using Microsoft.EntityFrameworkCore;
using tickets.Data;
using tickets.Models;

namespace tickets.Services.Tickets;

public class TicketService : ITicketService
{
    private readonly ApplicationContext context;

    public TicketService(ApplicationContext context)
    {
        this.context = context;
    }

    public void AddTicket(Ticket ticket)
        => context.Tickets.Add(ticket);

    public async Task<Ticket> GetTicketAsync(Guid Id) =>
        await context.Tickets
        .Include(x => x.Employee)
        .FirstOrDefaultAsync(x => x.Id.Equals(Id));

    public async Task<ICollection<Ticket>> GetTicketsAsync() =>
        await context.Tickets
        .Include(x => x.Employee)
        .ToListAsync();

    public async Task<ICollection<Ticket>> GetRecentlyAddedTicketsAsync() =>
        await context.Tickets
        .Include(x => x.Employee)
        .Take(5)
        .OrderByDescending(x => x.Created)
        .ToListAsync();

    public async Task<ICollection<Ticket>> GetTicketsByTeamAsync(Guid id) =>
        await context.Tickets
        .Include(x => x.Employee)
        .Where(x => x.Employee.TeamId.Equals(id))
        .ToListAsync();
}

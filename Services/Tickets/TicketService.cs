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
}

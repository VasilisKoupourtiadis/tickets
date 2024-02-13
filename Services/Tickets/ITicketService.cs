using tickets.Models;

namespace tickets.Services.Tickets
{
    public interface ITicketService
    {
        void AddTicket(Ticket ticket);
        Task<Ticket> GetTicketAsync(Guid Id);
        Task<ICollection<Ticket>> GetTicketsAsync();
        Task<ICollection<Ticket>> GetRecentlyAddedTicketsAsync();
    }
}
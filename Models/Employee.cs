using System.ComponentModel.DataAnnotations;

namespace tickets.Models;

public class Employee
{
    public Employee()
    {
        
    }

    public Employee(string fullName, string title, Team team)
    {
        FullName = fullName;
        Title = title;
        Team = team;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();

    [MaxLength(100)]
    public string FullName { get; private set; } = string.Empty;

    [MaxLength(100)]
    public string Title { get; private set; } = string.Empty;

    public Guid TeamId {  get; private set; }

    public Team Team { get; private set; } = null!;

    public ICollection<Ticket> Tickets { get; private set; } = new List<Ticket>();

    public void AddTicket(Ticket ticket) => Tickets.Add(ticket);
}
